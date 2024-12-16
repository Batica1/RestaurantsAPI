### Restaurant API

This is a simple application for creating a Restaurant API using Clean Architecture. The project is built with ASP.NET Core and demonstrates a layered approach to software design.
Overview

The application implements the following Clean Architecture layers:

Presentation Layer: Handles HTTP requests and responses (API endpoints).
Application Layer: Coordinates use cases and interacts with the Domain Layer.
Domain Layer: Contains the core business logic and entities (e.g., Restaurant).
Infrastructure Layer: Handles external concerns like database connections, Azure integration, and logging.

# This project follows

HTTP and REST APIs:
    Understand the basics of HTTP and RESTful principles.
    Implement clean and effective API design patterns.

Setting Up ASP.NET Core:
    Create and configure an ASP.NET Core Web API project.

Clean Architecture Principles:
    Learn how to structure projects for scalability, maintainability, and testability.

Database Integration:
    Integrate Microsoft SQL Server using Entity Framework Core.

Core API Features:
    Implement CRUD operations (Create, Read, Update, Delete).
    Add authentication and authorization for secured endpoints.

Performance Optimization:
    Explore techniques like pagination and caching.

Testing:
    Write unit and integration tests for robust API functionality.

Deployment:
    Learn how to deploy the API to Azure with ease.

# Who Is This For?

This project is aimed at developers who are:

Familiar with ASP.NET Core.
Interested in building scalable and robust web APIs.
Eager to adopt Clean Architecture principles for long-term maintainability.

# Getting Started

To get started with this project, follow these steps:

Clone the Repository
Clone the repository to your local machine using the following command:

# Install Dependencies
Navigate to the project directory and restore the NuGet packages needed for the project:

```cd restaurant-api```
```dotnet restore```

# Set Up the Database

Make sure you have SQL Server installed, or use a cloud-based instance like Azure SQL.
Update the connection string in the appsettings.json file to point to your database.

# Run Migrations
Run the database migrations to set up your tables:

    dotnet ef database update

# Run the Application
Start the API by running the following command:

    dotnet run

# Access the API
The API should now be running at http://localhost:7005 (or a different port, depending on your configuration). You can use tools like Postman or curl to test the API endpoints.

Explore the Layers

Review the structure of the Presentation, Application, Domain, and Infrastructure layers.
Start with the Controllers in the Presentation Layer, and follow the flow through the application.
