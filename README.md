# 🔐 IdentityForge

![GitHub last commit](https://img.shields.io/github/last-commit/gasbrieo/identity-forge)

IdentityForge is a full-featured user management system with registration, login (email and OAuth), and secure backend integration using Microsoft Identity.

> This is a fullstack project built for learning and portfolio demonstration purposes, combining modern frontend tools with a powerful .NET backend.

## ✨ Features

- ✅ Register and login with email + password
- ✅ OAuth login with Google and GitHub
- ✅ Role-based access control
- ✅ JWT issuance and validation
- ✅ Custom authentication UI
- ✅ PostgreSQL + EF Core
- ✅ Responsive SPA with shadcn/ui

## 🧱 Tech Stack

| Area     | Stack                                  |
| -------- | -------------------------------------- |
| Frontend | React, Vite, TanStack, shadcn/ui, Zod  |
| Backend  | .NET 8, PostgreSQL, Microsoft Identity |
| CI       | SonarQube                              |
| CD       | Netlify (Frontend), Docker (Backend)   |

## 📁 Project Structure

```
identityforge/
├── frontend/   # React SPA
├── backend/    # .NET Web API + Identity
```

## 🚀 Getting Started

See individual READMEs:

- [`frontend/README.md`](./frontend/README.md)
- [`backend/README.md`](./backend/README.md)

## 📌 Notes

- This project is not a production-ready app — it's built for learning and portfolio purposes.
- The goal is to demonstrate a real-world authentication flow using Microsoft Identity and a clean SPA frontend.
- All authentication logic is handled in the backend and integrated with the frontend via custom JWTs.
- OAuth providers like Google and GitHub are handled via Identity + external login flow.

## 🪪 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
