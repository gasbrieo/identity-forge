import { createFileRoute } from "@tanstack/react-router";

import { CallbackPage } from "~/features/auth";

export const Route = createFileRoute("/auth/callback")({
  loader: ({ location }) => {
    const search = new URLSearchParams(location.search);
    const code = search.get("code");

    if (!code) throw new Error("Invalid OAuth callback (no code found).");

    return { code };
  },
  component: CallbackPage,
});
