# CPRD Staff Management System

## Overview
The CPRD Staff Management System is a web application designed to manage staff assignments across different grants. It allows users to filter staff by grant and active status, and view staff details. The system is built using ASP.NET MVC for the backend and Bootstrap and jQuery for the frontend..

## Prerequisites
- .NET 6.0 SDK
- Visual Studio 2022 or Visual Studio Code
- SQL Server (or another database supported by Entity Framework Core)

## Setup Instructions


### Step 1: Clone the Repository
```
git clone https://github.com/your-repo/staff-management-system.git
cd staff-management-system
```

### Step 2: Configure the Database
Replace ***your-server-name*** name with your server name
``` "ConnectionStrings": {
    "DefaultConnection": "Server=your-server-name;Database=StaffManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true" 
    } 
```

### Step 3: Run database migrations

```
dotnet ef add migration YourMigrationName
dotnet ef database update
```

Build the project:

```
dotnet build
```

Run the application:
```
dotnet run
```

### Step 4: Explore the Application
Use the filters on the main page to view staff by grant and active status.

Click on a staff member to view detailed information.
