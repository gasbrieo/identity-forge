import { z } from "zod";

export const SendMagicLinkSchema = z.object({
  email: z.email(),
});

export type SendMagicLinkSchema = z.infer<typeof SendMagicLinkSchema>;
