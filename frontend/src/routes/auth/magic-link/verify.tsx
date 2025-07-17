import { createFileRoute, Await, Navigate, redirect } from "@tanstack/react-router";

import { verifyMagicLink } from "~/services/auth.service";
import { useAuthStore } from "~/stores/auth.store";

const VerifyMagicLinkPage = () => {
  const { verifyMagicLinkPromise } = Route.useLoaderData();

  const login = useAuthStore((state) => state.login);

  return (
    <Await
      promise={verifyMagicLinkPromise}
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

export const Route = createFileRoute("/auth/magic-link/verify")({
  beforeLoad: ({ context }) => {
    if (context.auth.isAuthenticated) {
      throw redirect({ to: "/dashboard" });
    }
  },
  loader: ({ location }) => {
    const search = new URLSearchParams(location.search);
    const token = search.get("token");

    if (!token) throw new Error("Invalid Magic Link verify (no token found).");

    const verifyMagicLinkPromise = verifyMagicLink({ token });

    return {
      verifyMagicLinkPromise,
    };
  },
  component: VerifyMagicLinkPage,
});
