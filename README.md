# Aladdin

Personal Finance & Productivity App (Angular, .NET Core)

![TypeScript](https://img.shields.io/badge/TypeScript-5.x-blue.svg)
![C#](https://img.shields.io/badge/CSharp-9.x-239120.svg)

![Angular](https://img.shields.io/badge/angular-%23DD0031.svg?style=for-the-badge&logo=angular&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)


## Prerequisites
- Node.js 18+ and npm 9+
- .NET 9.0 SDK

## Monorepo Setup
```sh
# Clone the repository
git clone https://github.com/2gbeh/aladdin.git
cd aladdin

# Install all dependencies
npm run install:all

# Start both client and server simultaneously
npm run dev
```

#### Client (Angular)
```sh
cd client
npm install
npm start

# → http://localhost:3000
```

#### Server (.NET Core)
```sh
cd server
dotnet restore
dotnet ef database update
dotnet run

# → https://localhost:8000 (HTTP)
# → https://localhost:8001 (HTTPS)
```

## Documentation

## Screenshots

## Resources
