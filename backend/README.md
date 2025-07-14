# 🧠 Backend — IdentityForge

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_identity-forge_backend?server=http%3A%2F%2Fsonarcloud.io)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_identity-forge_backend?server=https%3A%2F%2Fsonarcloud.io)

The backend API for IdentityForge handles authentication, user registration, and OAuth login using Microsoft Identity.

> Built with .NET 8 Web API, Microsoft Identity, and PostgreSQL.

## ✨ Features

- ✅ Register and login with email + password
- ✅ OAuth login with Google and GitHub
- ✅ JWT issuance and validation
- ✅ Secure password hashing and token handling
- ✅ Microsoft Identity integration
- ✅ PostgreSQL + EF Core
- ✅ Docker-ready
- ✅ Clean project structure with layered services

## 🧱 Tech Stack

| Layer     | Stack                          |
| --------- | ------------------------------ |
| Backend   | .NET 8 + Web API               |
| Auth      | Microsoft Identity + JWT       |
| OAuth     | Google & GitHub (via Identity) |
| Database  | PostgreSQL + EF Core           |
| Dev Tools | dotnet CLI, EF Core, Docker    |
| Deploy    | Railway / Render / Docker      |

## 📁 Project Structure

```bash
backend/
├── Controllers/       # API endpoints
├── Data/              # DbContext and Identity setup
├── Models/            # User and domain models
├── Services/          # Business logic (e.g., auth, tokens)
├── Program.cs         # Entry point
└── appsettings.json   # Configuration
```

## 🚀 Getting Started

1. Clone this repo
2. Set up a PostgreSQL database
3. Create your `appsettings.Development.json` with DB + JWT + OAuth configs
4. Run the app:

```bash
dotnet build
dotnet run
```

Or with Docker:

```bash
docker compose up --build
```
