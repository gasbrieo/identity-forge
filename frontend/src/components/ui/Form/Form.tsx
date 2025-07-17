import { createFormHook } from "@tanstack/react-form";

import { FormControl } from "./FormControl";
import { FormDescription } from "./FormDescription";
import { FormItem } from "./FormItem";
import { fieldContext, formContext } from "./FormItemContext";
import { FormLabel } from "./FormLabel";
import { FormMessage } from "./FormMessage";
import { SubmitButton } from "./SubmitButton";

export const { useAppForm, withForm } = createFormHook({
  fieldContext,
  formContext,
  fieldComponents: {
    FormLabel,
    FormControl,
    FormDescription,
    FormMessage,
    FormItem,
  },
  formComponents: {
    SubmitButton,
  },
});
