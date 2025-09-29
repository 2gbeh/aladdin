# Aladdin

Expense Tracker PWA w/Angular & .NET

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

> http://localhost:4200
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

> http://localhost:5288/swagger
```

## Documentation

## Screenshots

## Resources
