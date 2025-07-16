import { Await, createFileRoute } from "@tanstack/react-router";

import type { OAuthProviderSchema } from "~/schemas/auth.schemas";
import { exchangeOAuthCode } from "~/services/auth.service";

const OAuthCallbackPage = () => {
  const { exchangeOAuthCodePromise } = Route.useLoaderData();

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
        return <div>{data.email}</div>;
      }}
    </Await>
  );
};

export const Route = createFileRoute("/auth/callback")({
  loader: ({ location }) => {
    const search = new URLSearchParams(location.search);
    const code = search.get("code");
    const provider = search.get("state") as OAuthProviderSchema | null;

    if (!code) throw new Error("Invalid OAuth callback (no code found).");

    if (!provider) throw new Error("Invalid OAuth callback (no provider found).");

    const exchangeOAuthCodePromise = exchangeOAuthCode({ code, provider });

    return {
      exchangeOAuthCodePromise,
    };
  },
  component: OAuthCallbackPage,
});
