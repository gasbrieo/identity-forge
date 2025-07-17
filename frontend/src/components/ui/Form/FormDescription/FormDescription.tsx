import { cn } from "@gasbrieo/react-ui";

import { useFieldContext } from "../FormItemContext";

import type { FormDescriptionProps } from "./FormDescription.types";

export const FormDescription = ({ className, ...props }: FormDescriptionProps) => {
  const { formDescriptionId } = useFieldContext();

  return (
    <p
      data-slot="form-description"
      id={formDescriptionId}
      className={cn("text-muted-foreground text-sm", className)}
      {...props}
    />
  );
};
