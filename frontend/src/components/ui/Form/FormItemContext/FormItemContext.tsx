import { createFormHookContexts, useStore } from "@tanstack/react-form";
import { createContext, useContext } from "react";

import type { FormItemContextProps } from "./FormItemContext.types";

const { fieldContext, formContext, useFieldContext: _useFieldContext, useFormContext } = createFormHookContexts();

export const FormItemContext = createContext<FormItemContextProps>({} as FormItemContextProps);

export const useFieldContext = () => {
  const { id } = useContext(FormItemContext);
  const { name, store, ...fieldContext } = _useFieldContext();
  const errors = useStore(store, (state) => state.meta.errors);

  if (!fieldContext) {
    throw new Error("useFieldContext must be used within <FormItem>");
  }

  return {
    id,
    name,
    formItemId: `${id}-form-item`,
    formDescriptionId: `${id}-form-item-description`,
    formMessageId: `${id}-form-item-message`,
    errors,
    store,
    ...fieldContext,
  };
};

export { fieldContext, formContext, useFormContext };
