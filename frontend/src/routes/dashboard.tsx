import { createFileRoute, Outlet, redirect } from "@tanstack/react-router";

import { healthQueries } from "~/services/health.queries";

export const Route = createFileRoute("/dashboard")({
  beforeLoad: ({ context }) => {
    if (!context.auth.isAuthenticated) {
      throw redirect({ to: "/" });
    }
  },
  loader: async ({ context }) => {
    await context.queryClient.ensureQueryData(healthQueries.list());
  },
  component: Outlet,
});
