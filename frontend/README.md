# 💻 Frontend — PayTrack

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gasbrieo_paytrack_frontend?server=http%3A%2F%2Fsonarcloud.io)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gasbrieo_paytrack_frontend?server=https%3A%2F%2Fsonarcloud.io)

The frontend for Paytrack is focused on authentication with Clerk, clean UI, and full integration with a .NET backend.

> Built with React, Vite and Tanstack.

## ✨ Features

- ✅ Login with Clerk
- ✅ Add bills with name, value and due date
- ✅ Mark bills as paid
- ✅ Alerts for upcoming or overdue bills
- ✅ Modern UI with shadcn/ui and Tailwind CSS
- ✅ Integration with real backend
- ✅ Deploy with Netlify

## 🧱 Tech Stack

| Layer     | Stack                                |
| --------- | ------------------------------------ |
| Frontend  | React + Vite                         |
| Core Libs | TanStack Router, Form, Query         |
| Auth      | Clerk                                |
| Styling   | Tailwind CSS + shadcn/ui             |
| State     | Zustand                              |
| Dev Tools | TypeScript, ESLint, Prettier, Vitest |
| Deploy    | Netlify                              |

## 📁 Project Structure

```bash
src/
├── components/   # Reusable UI components (shadcn-based)
├── features/     # Feature-based folders (auth, bills, etc.)
├── hooks/        # Shared React hooks
├── lib/          # API client, auth utils, general helpers
├── routes/       # TanStack route entries and layouts
├── styles/       # Global styles
├── testing/      # Test utilities (mocks, custom render, etc.)
├── types/        # Shared TypeScript types
├── utils/        # Utilities not tied to features
```

## 🚀 Getting Started

1. Clone this repo
2. Set up Clerk project and get your keys
3. Create `.env` file with:

```env
VITE_API_URL=http://localhost:5100
VITE_CLERK_PUBLISHABLE_KEY=...
```

4. Start dev server:

```bash
npm install
npm run dev
```
