import { create } from "zustand";
import { persist } from "zustand/middleware";

import type { AuthResponse } from "~/types/auth.types";

export type User = {
  email: string;
  name: string;
  avatarUrl: string;
};

export type AuthState = {
  isAuthenticated: boolean;
  user: User | null;
  token: string | null;
  login: (auth: AuthResponse) => void;
  logout: () => void;
};

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      isAuthenticated: false,
      user: null,
      token: null,

      login: (auth) =>
        set({
          isAuthenticated: true,
          user: {
            email: auth.email,
            name: auth.name,
            avatarUrl: auth.avatarUrl,
          },
          token: auth.token,
        }),

      logout: () => set({ isAuthenticated: false, user: null, token: null }),
    }),
    {
      name: "auth",
    },
  ),
);
