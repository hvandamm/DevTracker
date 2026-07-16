# DevTracker API

A lightweight, cross-platform Project and Task Tracker Web API built with ASP.NET Core (Minimal APIs) and Entity Framework Core with SQLite.

This application demonstrates clean database relationships (One-to-Many), cascading deletes, database migrations, and modern ASP.NET Core design patterns.

---

## Technical Stack

* Runtime: .NET Core 8.0 SDK
* Database: SQLite (Self-contained file-based database)
* ORM: Entity Framework Core 8.0
* API Style: ASP.NET Core Minimal APIs
* Documentation: Swagger / OpenAPI

---

## Local Installation and Setup

Follow these steps to run the application locally on Windows, macOS, or Linux.

### Prerequisites

Ensure you have the .NET 8.0 SDK (or newer) installed on your machine. You can verify your installation by running:

```bash
dotnet --version
```

### 1. Clone the Repository
```bash
git clone [https://github.com/hvandamm/DevTracker.git](https://github.com/hvandamm/DevTracker.git)
```

### 2. Install the Entity Framework CLI Tool
To apply migrations and manage the database, you need the global dotnet-ef tool. Run the following command to install it:
```bash
dotnet tool install --global dotnet-ef --version 8.0.12
```
Note for Linux/macOS users: If the terminal cannot find the dotnet ef command after installation<br>
ensure that the global .NET tools directory is added to your system's PATH.<br>
You can add it temporarily for your current terminal session using:
```bash
export PATH="$PATH:$HOME/.dotnet/tools"
```
### 3. Create the database and apply migrations
```bash
dotnet ef database update
```

### 4. Run the Application.
```bash
dotnet run
```
