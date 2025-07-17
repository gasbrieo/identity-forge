import { cn } from "@gasbrieo/react-ui";

import { useFieldContext } from "../FormItemContext";

import type { FormMessageProps } from "./FormMessage.types";

export const FormMessage = ({ className, ...props }: FormMessageProps) => {
  const { errors, formMessageId } = useFieldContext();

  const body = errors.length ? String(errors.at(0)?.message ?? "") : props.children;

  if (!body) return null;

  return (
    <p data-slot="form-message" id={formMessageId} className={cn("text-destructive text-sm", className)} {...props}>
      {body}
    </p>
  );
};
