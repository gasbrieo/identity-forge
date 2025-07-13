# 🧠 Backend — PayTrack

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_paytrack_backend?server=http%3A%2F%2Fsonarcloud.io)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_paytrack_backend?server=https%3A%2F%2Fsonarcloud.io)

The backend API for PayTrack, responsible for managing bills, payment status, and alert logic.

> Built with .NET 8 Minimal APIs and PostgreSQL.

## ✨ Features

- ✅ Create and manage bills with due dates
- ✅ Mark bills as paid
- ✅ Return overdue bills for alert system
- ✅ Clerk-compatible authentication
- ✅ PostgreSQL + EF Core
- ✅ Docker-ready
- ✅ Clean project structure

## 🧱 Tech Stack

| Layer     | Stack                       |
| --------- | --------------------------- |
| Backend   | .NET 8 + Minimal APIs       |
| Database  | PostgreSQL + EF Core        |
| Auth      | Clerk                       |
| Dev Tools | dotnet CLI, EF Core, Docker |
| Deploy    | Railway / Render / Docker   |

## 📁 Project Structure

```bash
backend/
├── Controllers/       # API endpoints
├── Data/              # DbContext and Migrations
├── Models/            # Data models
├── Services/          # Business logic (e.g., due checks)
├── Program.cs         # Entry point
└── appsettings.json   # Configuration
```

## 🚀 Getting Started

1. Clone this repo
2. Set up a PostgreSQL database
3. Create your `appsettings.Development.json`
4. Run:

```bash
dotnet build
dotnet run
```

Or with Docker:

```bash
docker compose up --build
```
