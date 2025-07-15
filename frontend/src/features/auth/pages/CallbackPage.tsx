import { useEffect } from "react";
import axios from "redaxios";

import { Route } from "~/routes/auth/callback";

export const CallbackPage = () => {
  const { code } = Route.useLoaderData();
  const navigate = Route.useNavigate();

  useEffect(() => {
    async function exchangeCode() {
      try {
        const res = await axios.post("http://localhost:5001/api/v1/auth/google/exchange", {
          code,
        });

        const data = res.data;
        console.log("✅ Authenticated user:", data);

        // salva token da sua app
        localStorage.setItem("auth_token", data.token);

        // redireciona
        navigate({ to: "/dashboard" });
      } catch (err) {
        console.error("❌ Error exchanging code:", err);
      }
    }

    exchangeCode();
  }, [code, navigate]);

  return (
    <main className="flex min-h-screen flex-col items-center justify-center bg-background text-center">
      <div className="animate-spin rounded-full h-10 w-10 border-t-2 border-primary mb-4" />
      <h1 className="text-lg font-semibold">Logging you in...</h1>
      <p className="text-muted-foreground text-sm mt-2">Please wait while we complete your authentication.</p>
    </main>
  );
};
