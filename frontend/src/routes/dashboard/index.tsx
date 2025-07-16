import { useSuspenseQuery } from "@tanstack/react-query";
import { createFileRoute } from "@tanstack/react-router";

import { Button } from "~/components/ui/button";
import { healthQueries } from "~/services/health.queries";

const DashboardPage = () => {
  const navigate = Route.useNavigate();

  const { data, isLoading, isError, error, refetch, isFetching, isSuccess } = useSuspenseQuery(healthQueries.list());

  return (
    <main className="p-4 space-y-4">
      <Button onClick={() => navigate({ to: "/auth/logout", replace: true })}>Log out</Button>

      <section className="mt-4">
        <h2 className="text-xl font-bold">Health Check</h2>

        {isLoading && <p className="text-muted-foreground">Loading health...</p>}

        {isError && (
          <div className="space-y-2">
            <p className="text-red-500">Failed to load health: {(error as Error).message}</p>
            <Button variant="outline" onClick={() => refetch()} disabled={isFetching}>
              {isFetching ? "..." : "Retry"}
            </Button>
          </div>
        )}

        {isSuccess && (
          <div className="mt-2 rounded bg-muted p-4 text-sm font-mono space-y-2">
            <pre>{JSON.stringify(data, null, 2)}</pre>
            <Button variant="outline" onClick={() => refetch()} disabled={isFetching}>
              {isFetching ? "..." : "Refresh"}
            </Button>
          </div>
        )}
      </section>
    </main>
  );
};

export const Route = createFileRoute("/dashboard/")({
  loader: async ({ context }) => {
    await context.queryClient.ensureQueryData(healthQueries.list());
  },
  component: DashboardPage,
});
