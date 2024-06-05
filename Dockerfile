# Stage 1: Build the Blazor WebAssembly project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["src/BlazorPocket.WebAssembly/BlazorPocket.WebAssembly.csproj", "src/BlazorPocket.WebAssembly/"]
COPY ["src/BlazorPocket.Shared/BlazorPocket.Shared.csproj", "src/BlazorPocket.Shared/"]
COPY ["src/PocketBaseClient.BlazorPocket/PocketBaseClient.BlazorPocket.csproj", "src/PocketBaseClient.BlazorPocket/"]
COPY ["pbcodegen/src/PocketBaseClient/PocketBaseClient.csproj", "pbcodegen/src/PocketBaseClient/"]
COPY ["sdk/pocketbase-csharp-sdk/pocketbase-csharp-sdk.csproj", "sdk/pocketbase-csharp-sdk/"]

# Restore dependencies
RUN dotnet restore "src/BlazorPocket.WebAssembly/BlazorPocket.WebAssembly.csproj"

# Copy the rest of the files
COPY . .

# Build the project
WORKDIR "/src/src/BlazorPocket.WebAssembly"
RUN dotnet build "BlazorPocket.WebAssembly.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BlazorPocket.WebAssembly.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 2: Setup Apache HTTP Server with HTTPS
FROM httpd:2.4-alpine AS final

# Install openssl and enable mod_ssl
RUN apk add --no-cache openssl && \
    sed -i '/^#LoadModule ssl_module/s/^#//' /usr/local/apache2/conf/httpd.conf && \
    sed -i '/^#LoadModule socache_shmcb_module/s/^#//' /usr/local/apache2/conf/httpd.conf

# Generate a self-signed certificate
RUN mkdir -p /usr/local/apache2/conf/ssl && \
    openssl req -x509 -newkey rsa:4096 -sha256 -days 3650 -nodes \
    -keyout /usr/local/apache2/conf/ssl/private.key -out /usr/local/apache2/conf/ssl/certificate.crt \
    -subj "/C=US/ST=State/L=City/O=Organization/CN=localhost"

# Copy the published files from the build stage
COPY --from=build /app/publish/wwwroot /usr/local/apache2/htdocs/

# Copy custom httpd configuration to enable SSL
COPY httpd-ssl.conf /usr/local/apache2/conf/extra/httpd-ssl.conf
RUN echo "Include conf/extra/httpd-ssl.conf" >> /usr/local/apache2/conf/httpd.conf

# Configure Apache to redirect 404 errors to the root
RUN echo "ErrorDocument 404 /index.html" >> /usr/local/apache2/conf/httpd.conf

EXPOSE 80
EXPOSE 443

CMD ["httpd-foreground"]
