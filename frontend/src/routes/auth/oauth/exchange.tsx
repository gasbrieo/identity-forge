import { createFileRoute, Await, Navigate, redirect } from "@tanstack/react-router";

import { exchangeOAuthCode } from "~/services/auth.service";
import { useAuthStore } from "~/stores/auth.store";
import type { OAuthProvider } from "~/types/auth.types";

const ExchangeOAuthCodePage = () => {
  const { exchangeOAuthCodePromise } = Route.useLoaderData();

  const login = useAuthStore((state) => state.login);

  return (
    <Await
      promise={exchangeOAuthCodePromise}
      fallback={
        <main className="flex min-h-screen flex-col items-center justify-center bg-background text-center">
          <div className="animate-spin rounded-full h-10 w-10 border-t-2 border-primary mb-4" />
          <h1 className="text-lg font-semibold">Logging you in...</h1>
          <p className="text-muted-foreground text-sm mt-2">Please wait while we complete your authentication.</p>
        </main>
      }
    >
      {(data) => {
        login(data);

        return <Navigate to="/dashboard" replace />;
      }}
    </Await>
  );
};

export const Route = createFileRoute("/auth/oauth/exchange")({
  beforeLoad: ({ context }) => {
    if (context.auth.isAuthenticated) {
      throw redirect({ to: "/dashboard" });
    }
  },
  loader: ({ location }) => {
    const search = new URLSearchParams(location.search);
    const code = search.get("code");
    const provider = search.get("state") as OAuthProvider | null;

    if (!code) throw new Error("Invalid OAuth exchange (no code found).");

    if (!provider) throw new Error("Invalid OAuth exchange (no provider found).");

    const exchangeOAuthCodePromise = exchangeOAuthCode({ code, provider });

    return {
      exchangeOAuthCodePromise,
    };
  },
  component: ExchangeOAuthCodePage,
});
