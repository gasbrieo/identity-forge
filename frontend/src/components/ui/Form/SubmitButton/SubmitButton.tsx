import { cn } from "@gasbrieo/react-ui";
import { Loader2Icon } from "lucide-react";

import { Button } from "../../button";
import { useFormContext } from "../FormItemContext";

import type { SubmitButtonProps } from "./SubmitButton.types";

export const SubmitButton = ({ children, className, isLoading, ...props }: SubmitButtonProps) => {
  const form = useFormContext();

  return (
    <form.Subscribe selector={(state) => [state.canSubmit, state.isSubmitting]}>
      {([canSubmit, isSubmitting]) => {
        const loadingState = isLoading ?? isSubmitting;

        return (
          <Button className={cn("w-full", className)} disabled={!canSubmit || loadingState} type="submit" {...props}>
            {children}
            {loadingState && <Loader2Icon className="ml-2 h-4 w-4 animate-spin" />}
          </Button>
        );
      }}
    </form.Subscribe>
  );
};
