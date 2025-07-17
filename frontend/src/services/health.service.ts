import { api } from "~/lib/axios/api";
import type { HealthResponse } from "~/types/health.types";

export const getHealth = async () => {
  const response = await api.post<HealthResponse>("/api/health");
  return response.data;
};
