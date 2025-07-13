# 💸 PayTrack

![GitHub last commit](https://img.shields.io/github/last-commit/gasbrieo/paytrack)

PayTrack is a personal finance app where users register upcoming payments and get notified if they forget to mark them as paid.

> This is a fullstack project built with modern technologies on both frontend and backend.

## ✨ Features

- ✅ Track upcoming payments
- ✅ Mark bills as paid
- ✅ Receive alerts for overdue items
- ✅ Real backend with API + DB
- ✅ Responsive and clean interface

## 🧱 Tech Stack

| Area     | Stack                            |
| -------- | -------------------------------- |
| Frontend | React, Vite, TanStack            |
| Backend  | .NET 8, PostgreSQL, Minimal APIs |
| CI       | SonarCloud                       |
| CD       | Netlify                          |

## 📁 Project Structure

```
paytrack/
├── frontend/   # React SPA
├── backend/    # .NET Minimal API
```

## 🚀 Getting Started

See individual READMEs:

- [`frontend/README.md`](./frontend/README.md)
- [`backend/README.md`](./backend/README.md)

## 📌 Notes

- This project is not a production-ready app — it's built for learning and portfolio purposes.
- The goal is to demonstrate a real-world flow: authentication, state management, and API integration.
- All data is persisted in a real database, with proper backend validation and business rules.
- Authentication is handled via Clerk, and the backend enforces logic such as due date checks and payment status.

## 🪪 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
