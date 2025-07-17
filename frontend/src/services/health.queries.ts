import { queryOptions } from "@tanstack/react-query";

import { getHealth } from "./health.service";

export const healthQueries = {
  all: ["health"],
  list: () =>
    queryOptions({
      queryKey: [...healthQueries.all, "list"],
      queryFn: () => getHealth(),
    }),
};
