# BlazorPocket

[![Build](https://github.com/neozhu/BlazorPocketApp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/neozhu/BlazorPocketApp/actions/workflows/dotnet.yml)


BlazorPocket is a lightweight web application template that leverages the latest .NET 8.0 Blazor Web App with InteractiveAuto render mode and PocketBase for backend data storage. This project aims to streamline the development process, minimize repetitive coding, and provide a quick start for building efficient web applications.

## Features
- **Blazor Web App with .NET 8.0**: Utilizes the latest features and improvements in .NET 8.0 Blazor.
- **InteractiveAuto Render Mode**: Offers enhanced interactivity and responsiveness.
- **PocketBase Integration**: Simple and efficient data storage solution with PocketBase.
- **Quick Setup**: Pre-configured to reduce setup time and repetitive coding.

## Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PocketBase](https://pocketbase.io/)
- [Node.js](https://nodejs.org/) (for front-end development)

### Installation


1. **Clone the repository:**
    ```sh
    git clone https://github.com/neozhu/BlazorPocket.git
    cd BlazorPocket
    ```
    
2. **Add PocketBaseClient subtree:**
    ```sh
    git subtree add --prefix pbcodegen https://github.com/iluvadev/PocketBaseClient.git main --squash
    ```

3. **Add PocketBase C# SDK subtree:**
    ```sh
    git subtree add --prefix sdk https://github.com/iluvadev/pocketbase-csharp-sdk.git master --squash
    ```

3. **Setup PocketBase:**
    - Download and run PocketBase following the [official documentation](https://pocketbase.io/docs/).
    - Configure the PocketBase instance and make note of the endpoint URL.

4. **Configure the Blazor App:**
    - Update the configuration file in the Blazor project to point to your PocketBase instance.

5. **Restore .NET dependencies:**
    ```sh
    dotnet restore
    ```

6. **Build and run the Blazor App:**
    ```sh
    dotnet run
    ```

### Usage
- Open your browser and navigate to `https://localhost:5001`.
- You should see the BlazorPocket application running.
- Explore the sample components and understand the integration with PocketBase.

## Project Structure
- **/BlazorPocket.Client**: Contains the Blazor WebAssembly project.
- **/BlazorPocket.Server**: Contains the ASP.NET Core server project.
- **/BlazorPocket.Shared**: Contains shared code and models.

## Contributing
Contributions are welcome! Please feel free to submit issues, fork the repository, and send pull requests.

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add your feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Create a new Pull Request.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements
- [.NET Team](https://dotnet.microsoft.com/) for creating an amazing development framework.
- [PocketBase Team](https://pocketbase.io/) for providing a simple and efficient backend solution.

