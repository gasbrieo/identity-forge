import { Slot } from "@radix-ui/react-slot";

import { useFieldContext } from "../FormItemContext";

import type { FormControlProps } from "./FormControl.types";

export const FormControl = ({ ...props }: FormControlProps) => {
  const { errors, formItemId, formDescriptionId, formMessageId } = useFieldContext();

  return (
    <Slot
      data-slot="form-control"
      id={formItemId}
      aria-describedby={!errors.length ? `${formDescriptionId}` : `${formDescriptionId} ${formMessageId}`}
      aria-invalid={!!errors.length}
      {...props}
    />
  );
};
