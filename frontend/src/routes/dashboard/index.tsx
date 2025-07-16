import { createFileRoute } from "@tanstack/react-router";

const DashboardPage = () => {
  return <main></main>;
};

export const Route = createFileRoute("/dashboard/")({
  component: DashboardPage,
});
