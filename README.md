# Aladdin

Personal Finance & Productivity App (Angular, .NET Core)

![TypeScript](https://img.shields.io/badge/TypeScript-5.x-blue.svg)
![C#](https://img.shields.io/badge/CSharp-9.x-239120.svg)


![Angular](https://img.shields.io/badge/angular-%23DD0031.svg?style=for-the-badge&logo=angular&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)

## Setup

```sh
# Clone the repository
git clone https://github.com/2gbeh/aladdin.git
```

```sh
# Move into the Angular client app directory
cd aladdin/client

# Clear npm cache to avoid issues with corrupted or stale packages (optional but helpful)
npm cache clean --force

# Install client dependencies
npm install

# If you hit peer dependency conflicts, try the legacy flag instead
npm install --legacy-peer-deps

# Start the Angular dev server (with hot reload)
npm start

> http://localhost:3000
```

```sh
# Move into the .NET server API directory
cd aladdin/server

# Restore NuGet packages
dotnet restore

# Apply the latest EF Core migrations to your database
dotnet ef database update

# Troubleshooting: install the EF Core CLI tool globally (if not already installed)
dotnet tool install --global dotnet-ef

# Run the web server with hot reload
dotnet watch run

> http://localhost:8000
```

## Documentation

## Screenshots

## Resources
