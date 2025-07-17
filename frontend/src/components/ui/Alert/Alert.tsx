import { cn } from "@gasbrieo/react-ui";

import type { AlertProps } from "./Alert.types";
import { alertVariants } from "./Alert.variants";

export const Alert = ({ className, variant, ...props }: AlertProps) => {
  return <div data-slot="alert" role="alert" className={cn(alertVariants({ variant }), className)} {...props} />;
};
