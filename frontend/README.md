# 💻 Frontend — IdentityForge

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_identity-forge_frontend?server=http%3A%2F%2Fsonarcloud.io)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_identity-forge_frontend?server=https%3A%2F%2Fsonarcloud.io)

The frontend for IdentityForge is focused on user registration, login (including OAuth), and secure integration with a .NET backend using Microsoft Identity.

> Built with React, Vite and TanStack.

## ✨ Features

- ✅ Register and login with email + password
- ✅ Login with Google and GitHub via custom backend OAuth
- ✅ JWT authentication and protected routes
- ✅ Form validation with Zod and TanStack Form
- ✅ Modern UI with shadcn/ui and Tailwind CSS
- ✅ Full integration with .NET Identity backend
- ✅ Deploy with Netlify

## 🧱 Tech Stack

| Layer     | Stack                                |
| --------- | ------------------------------------ |
| Frontend  | React + Vite                         |
| Core Libs | TanStack Router, Form, Query         |
| Auth      | Custom (JWT via Microsoft Identity)  |
| Styling   | Tailwind CSS + shadcn/ui             |
| Forms     | TanStack Form + Zod                  |
| Dev Tools | TypeScript, ESLint, Prettier, Vitest |
| Deploy    | Netlify                              |

## 📁 Project Structure

```bash
src/
├── components/   # Reusable UI components (shadcn-based)
├── features/     # Feature-based folders (auth, profile, etc.)
├── hooks/        # Shared React hooks
├── lib/          # API client, auth, validation utils
├── routes/       # TanStack route entries and layouts
├── styles/       # Global styles
├── testing/      # Test utilities (mocks, custom render, etc.)
├── types/        # Shared TypeScript types
├── utils/        # Utilities not tied to features
```

## 🚀 Getting Started

1. Clone this repo
2. Set up your backend with Microsoft Identity
3. Create a `.env` file with:

```env
VITE_API_URL=http://localhost:5100
```

4. Start the dev server:

```bash
npm install
npm run dev
```
