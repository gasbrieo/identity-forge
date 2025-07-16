import { createFileRoute } from "@tanstack/react-router";

import { Button } from "~/components/ui/button";

const DashboardPage = () => {
  const navigate = Route.useNavigate();

  return (
    <main>
      <Button onClick={() => navigate({ to: "/auth/logout", replace: true })}>Log out</Button>
    </main>
  );
};

export const Route = createFileRoute("/dashboard/")({
  component: DashboardPage,
});
