import type { ComponentProps } from "react";

import type { Button } from "../../button";

export interface SubmitButtonProps extends ComponentProps<typeof Button> {
  isLoading?: boolean;
}
