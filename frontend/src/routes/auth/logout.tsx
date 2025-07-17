import { createFileRoute, redirect } from "@tanstack/react-router";

export const Route = createFileRoute("/auth/logout")({
  preload: false,
  beforeLoad: ({ context }) => {
    if (!context.auth.isAuthenticated) {
      throw redirect({ to: "/" });
    }
  },
  loader: async ({ context }) => {
    context.auth.logout();
    context.queryClient.clear();
    throw redirect({ to: "/" });
  },
});
