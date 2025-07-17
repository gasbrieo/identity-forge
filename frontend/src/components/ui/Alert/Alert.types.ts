import type { VariantProps } from "class-variance-authority";
import type { ComponentProps } from "react";

import type { alertVariants } from "./Alert.variants";

export interface AlertProps extends ComponentProps<"div">, VariantProps<typeof alertVariants> {}
