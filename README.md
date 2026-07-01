# Product Database API

A C# REST API for managing product database operations. This project provides endpoints for creating, reading, updating, and deleting product information.

## Features

- 🔄 RESTful API architecture
- 📦 Product management operations (CRUD)
- 🛡️ Data validation and error handling
- 📝 Database integration
- 🔌 Easy-to-use API endpoints

## Tech Stack

- **Language**: C#
- **Framework**: ASP.NET Core
- **Database**: SQL Server (or your preferred database)

## Getting Started

### Prerequisites

- .NET 6.0 or higher
- Visual Studio 2022 (or Visual Studio Code)
- SQL Server (local or cloud instance)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/liewvk/ProductDatabaseApi.git
cd ProductDatabaseApi
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string-here"
  }
}
```

4. Run database migrations (if applicable):
```bash
dotnet ef database update
```

5. Start the application:
```bash
dotnet run
```

The API will be available at `https://localhost:5000` or `http://localhost:5000`

## API Endpoints

### Products

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product

## Project Structure

```
ProductDatabaseApi/
├── Controllers/        # API controllers
├── Models/            # Data models
├── Services/          # Business logic
├── Data/              # Database context and migrations
├── appsettings.json   # Configuration
└── Program.cs         # Application entry point
```

## Configuration

Configuration settings can be modified in `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

## Usage

### Example: Create a Product

```bash
curl -X POST https://localhost:5000/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Sample Product",
    "description": "A sample product",
    "price": 29.99
  }'
```

### Example: Get All Products

```bash
curl https://localhost:5000/api/products
```

## Development

### Running Tests

```bash
dotnet test
```

### Building the Project

```bash
dotnet build
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is currently unlicensed. Consider adding a license (MIT, Apache 2.0, etc.) for your project.

## Support

For issues, questions, or suggestions, please open an issue on GitHub.

## Authors

- **liewvk** - Initial work

## Changelog

### Version 1.0.0
- Initial release
- Basic CRUD operations for products
