import { Button } from "@gasbrieo/react-ui";
import { Link } from "@tanstack/react-router";
import { ShieldIcon } from "lucide-react";

export const RegisterPage = () => {
  return (
    <main className="flex min-h-screen flex-col items-center justify-center bg-background px-4">
      <div className="flex flex-col items-center gap-4 text-center">
        <ShieldIcon className="h-10 w-10 text-primary" />
        <h1 className="text-xl font-semibold">Create your account</h1>
      </div>

      <div className="mt-8 flex w-full max-w-xs flex-col gap-3">
        <Button variant="outline">
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

        <Button variant="outline">Continue with Email</Button>
      </div>

      <p className="mt-6 text-sm text-muted-foreground">
        Already have an account?{" "}
        <Link to="/auth/login" className="font-medium hover:underline">
          Log in
        </Link>
      </p>
    </main>
  );
};
