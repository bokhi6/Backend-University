# My MVC API

This project is a .NET MVC backend application designed to serve an Angular frontend. It provides a structured way to manage API requests and serve web pages.

## Project Structure

- **Controllers**: Contains the controllers that handle incoming requests.
  - `HomeController.cs`: Manages the home page of the application.
  - `ApiController.cs`: Handles API requests and responses.

- **Models**: Contains the data models used in the application.
  - `ResponseModel.cs`: Defines the structure of the response data.

- **Views**: Contains the Razor views for rendering HTML.
  - `Home/Index.cshtml`: The Razor view for the home page.

- **wwwroot**: Contains static files such as CSS and JavaScript.
  - `css`: Directory for CSS files.
  - `js`: Directory for JavaScript files.

- **Program.cs**: The entry point of the application.

- **Startup.cs**: Configures services and the application's request pipeline.

- **appsettings.json**: Configuration settings for the application.

- **appsettings.Development.json**: Development-specific configuration settings.

- **my-mvc-api.csproj**: Project file defining dependencies and build settings.

## Getting Started

1. Clone the repository.
2. Navigate to the project directory.
3. Run the application using the command:
   ```
   dotnet run
   ```
4. Access the application at `http://localhost:5000`.

## API Endpoints

- **GET /api/response**: Returns a JSON response with status and message.

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.