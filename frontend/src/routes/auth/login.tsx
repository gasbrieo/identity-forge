import { createFileRoute, Link, redirect } from "@tanstack/react-router";
import { ShieldIcon } from "lucide-react";

import { Button } from "~/components/ui/button";
import { loginWithOAuth } from "~/services/auth.service";
import type { OAuthProvider } from "~/types/auth.types";

const LoginPage = () => {
  const handleOAuthLogin = async (provider: OAuthProvider) => {
    const { url } = loginWithOAuth({ provider });
    window.location.href = url;
  };

  return (
    <main className="flex min-h-screen flex-col items-center justify-center bg-background px-4">
      <div className="flex flex-col items-center gap-4 text-center">
        <ShieldIcon className="h-10 w-10 text-primary" />
        <h1 className="text-xl font-semibold">Log in to IdentityForge</h1>
      </div>

      <div className="mt-8 flex w-full max-w-xs flex-col gap-3">
        <Button variant="outline" onClick={() => handleOAuthLogin("google")}>
          <svg className="mr-2 h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 533.5 544.3">
            <path
              fill="#4285f4"
              d="M533.5 278.4c0-17.4-1.6-34.1-4.7-50.4H272v95.4h146.9c-6.3 34.3-25.1 63.4-53.5 83v68h86.2c50.5-46.5 81.9-114.8 81.9-196z"
            />
            <path
              fill="#34a853"
              d="M272 544.3c72.7 0 133.6-24 178.1-65.4l-86.2-68c-24 16-54.7 25.5-91.9 25.5-70.7 0-130.6-47.7-152-111.4h-89v69.8c44.3 88.1 135 149.5 241 149.5z"
            />
            <path
              fill="#fbbc04"
              d="M120 325c-10.6-31.7-10.6-65.7 0-97.4V157.8h-89c-38.1 75.6-38.1 165.1 0 240.7l89-69.8z"
            />
            <path
              fill="#ea4335"
              d="M272 107.6c38.6-.6 75.6 13.6 103.9 39.4l77.4-77.4C407 24.8 347.6 0 272 0 166 0 75.3 61.4 31 149.5l89 69.8c21.4-63.7 81.3-111.4 152-111.7z"
            />
          </svg>
          Continue with Google
        </Button>

        <Button variant="outline" onClick={() => handleOAuthLogin("github")}>
          <svg className="mr-2 h-4 w-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor">
            <path
              fillRule="evenodd"
              clipRule="evenodd"
              d="M12 0C5.37 0 0 5.42 0 12.11c0 5.35 3.438 9.89 8.205 11.49.6.11.82-.26.82-.58 
      0-.29-.01-1.05-.015-2.06-3.338.73-4.042-1.64-4.042-1.64-.546-1.4-1.333-1.77-1.333-1.77-1.09-.76.083-.74.083-.74 
      1.205.09 1.84 1.26 1.84 1.26 1.07 1.85 2.807 1.31 3.492 1 .108-.8.42-1.31.763-1.61-2.665-.31-5.466-1.36-5.466-6.05 
      0-1.34.465-2.44 1.235-3.29-.135-.31-.54-1.57.105-3.27 0 0 1.005-.33 3.3 1.26.96-.27 1.98-.4 3-.4s2.04.13 
      3 .4c2.28-1.59 3.285-1.26 3.285-1.26.645 1.7.24 2.96.12 3.27.765.85 1.23 1.95 1.23 3.29 0 4.7-2.805 
      5.73-5.475 6.04.435.38.81 1.12.81 2.27 0 1.64-.015 2.96-.015 3.36 0 .32.21.7.825.58C20.565 
      22 24 17.46 24 12.11 24 5.42 18.63 0 12 0z"
            />
          </svg>
          Continue with GitHub
        </Button>

        <Button variant="outline" asChild>
          <Link to="/auth/magic-link/send">Continue with Magic Link</Link>
        </Button>
      </div>
    </main>
  );
};

export const Route = createFileRoute("/auth/login")({
  beforeLoad: ({ context }) => {
    if (context.auth.isAuthenticated) {
      throw redirect({ to: "/dashboard" });
    }
  },
  component: LoginPage,
});
