# AlumniNetworkApi

### Overview

The Alumni Network API is a C# project that provides a RESTful API for managing alumni network data. The API allows users to perform CRUD operations on alumni, events, and other related entities. The project utilizes Entity Framework Core for database management and supports migrations for version control and seamless schema updates. The API also includes Swagger documentation for easy testing and integration.

---
### Contributors

* Kristian Boberg - https://github.com/kboberg98
* Tord Vetle Gjertsen - https://github.com/Tartarpaste
* Pavel Ibrahim - https://github.com/bavelibrahim
* Magomed Saiew - https://github.com/mago1234

---
### Features


* CRUD operations for users, groups, and other related entities
* Pagination and filtering for retrieving data
* Authentication and authorization
* RESTful API with Swagger documentation
* Database management with Entity Framework Core and migrations
--- 
### Prerequisites

* .NET Core SDK 3.1 or later
* Entity Framework Core
* A compatible database SQL Server, 
   
--- 
### Installation

Clone the repository:

    git clone https://github.com/Alumni-Universe/AlumniNetworkAp.git
    

Navigate to the project directory:

    cd AlumniNetworkApi


Restore the NuGet packages:

    dotnet restore


Update the connection string in the appsettings.json file to point to your database server.

--- 
### Database Setup

To set up the database using migrations, follow these steps:

Open a terminal in the project directory.
Run the following command to create the initial migration:

    dotnet ef migrations add InitialCreate

Run the following command to apply the migration and create/update the database schema:

    dotnet ef database update

--- 
### Swagger Documentation and API Endpoints

After running the application, you can access the Swagger documentation by navigating to /swagger in your browser (e.g., http://localhost:5000/swagger). The API documentation contains details about the available endpoints, their parameters, and expected responses.

Here is a brief overview of the main API endpoints:

    GET /api/resource: Fetches a list of all resources.
    GET /api/resource/{id}: Fetches a specific resource by its ID.
    POST /api/resource: Creates a new resource.
    PUT /api/resource/{id}: Updates an existing resource by its ID.
    DELETE /api/resource/{id}: Deletes a specific resource by its ID.

resource can be replaced by:
* AlumniUser
* AlumniGroup
* RSVP
* Event
* Topic
* Post

---
### Run the project:

    dotnet run

Access the application by navigating to the URL provided in the terminal output.
Visit the Swagger documentation page (e.g., http://localhost:7100/swagger) to explore and test the API endpoints.

When this project is properly setup you can navigate to the frontend repo for a frontend that corresponds with the endpoints of this api
Link: https://github.com/Alumni-Universe/alumni-app


