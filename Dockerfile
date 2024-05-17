#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base


# Generate a self-signed certificate
RUN mkdir -p /app/https && \
    openssl req -x509 -newkey rsa:4096 -sha256 -days 3650 -nodes \
    -keyout /app/https/private.key -out /app/https/certificate.crt \
    -subj "/C=US/ST=State/L=City/O=Organization/CN=localhost" && \
    openssl pkcs12 -export -out /app/https/aspnetapp.pfx \
    -inkey /app/https/private.key -in /app/https/certificate.crt \
    -password pass:CREDENTIAL_PLACEHOLDER


# Setup environment variables for the application to find the certificate
ENV ASPNETCORE_URLS=http://+:80;https://+:443
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="CREDENTIAL_PLACEHOLDER"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/https/aspnetapp.pfx"

WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BlazorPocket/BlazorPocket.csproj", "src/BlazorPocket/"]
COPY ["src/BlazorPocket.Client/BlazorPocket.Client.csproj", "src/BlazorPocket.Client/"]
COPY ["src/PocketBaseClient.BlazorPocket/PocketBaseClient.BlazorPocket.csproj", "src/PocketBaseClient.BlazorPocket/"]
COPY ["pbcodegen/src/PocketBaseClient/PocketBaseClient.csproj", "pbcodegen/src/PocketBaseClient/"]
COPY ["sdk/pocketbase-csharp-sdk/pocketbase-csharp-sdk.csproj", "sdk/pocketbase-csharp-sdk/"]
RUN dotnet restore "./src/BlazorPocket/BlazorPocket.csproj"
COPY . .
WORKDIR "/src/src/BlazorPocket"
RUN dotnet build "./BlazorPocket.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BlazorPocket.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorPocket.dll"]