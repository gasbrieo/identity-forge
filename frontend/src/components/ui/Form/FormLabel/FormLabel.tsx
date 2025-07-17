import { cn } from "@gasbrieo/react-ui";

import { Label } from "../../Label";
import { useFieldContext } from "../FormItemContext";

import type { FormLabelProps } from "./FormLabel.types";

export const FormLabel = ({ className, ...props }: FormLabelProps) => {
  const { formItemId, errors } = useFieldContext();

  return (
    <Label
      data-slot="form-label"
      data-error={!!errors.length}
      className={cn("data-[error=true]:text-destructive", className)}
      htmlFor={formItemId}
      {...props}
    />
  );
};
