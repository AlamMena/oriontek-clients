
## Getting Started

To get started with this project, you can either run.

### Prerequisites

- **Docker**: Ensure you have Docker installed to use containerization.
- **.NET 8 SDK**: Required to build and run the backend.
- **Node.js**: Required to run the frontend with Next.js.

### Running

1. **Clone the repository**:

   ```bash
   git clone https://your-repository-url.git](https://github.com/AlamMena/oriontek-clients.git
2. **Init the database**
   ```bash
   cd server
   docker-compose up --build
3. **Add the db migrations**
   ```bash
    cd OriontekClientsServer.Infrastucture.Persitence
    dotnet ef database update
4. **Test the server in swagger (server must be serverd in port 5000)**
5. **Go to the web-app folder install and run the app**
   ```bash
   cd web-app/
   npm i
   run dev  
## Technologies

### Backend
- **.NET 8**: The latest version of .NET for building the backend API.
- **Entity Framework Core (EF Core)**: ORM for interacting with the database.
- **MediatR**: A library for handling requests and responses using the mediator pattern.
- **Fluent API**: A configuration method for defining entity relationships and constraints in EF Core.
- **Swagger**: A tool for API documentation and testing.
- **Docker**: Used for containerization to make the development environment consistent and easy to deploy.

### Frontend
- **Next.js**: React framework for building the frontend of the application.
- **NextUI**: A component library for building the user interface.
- **Iconify**: Icon library for adding scalable vector icons.
- **React Hook Form**: Form handling library to manage form state and validation.
- **Axios**: For making HTTP requests to the backend API.
