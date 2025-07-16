export interface HealthEntry {
  data: Record<string, unknown>;
  duration: string;
  status: string;
  tags: string[];
}

export type HealthEntries = Record<string, HealthEntry>;

export interface HealthResponse {
  status: string;
  totalDuration: string;
  entries: HealthEntries;
}
