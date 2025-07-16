import { z } from "zod";

export const OAuthProviderSchema = z.enum(["google", "github"]);

export type OAuthProviderSchema = z.infer<typeof OAuthProviderSchema>;

export const OAUTH_PROVIDERS: Record<OAuthProviderSchema, { authUrl: string; clientId: string; scope: string }> = {
  google: {
    authUrl: "https://accounts.google.com/o/oauth2/v2/auth",
    clientId: import.meta.env.VITE_OAUTH_GOOGLE_CLIENT_ID!,
    scope: "openid email profile",
  },
  github: {
    authUrl: "https://github.com/login/oauth/authorize",
    clientId: import.meta.env.VITE_OAUTH_GITHUB_CLIENT_ID!,
    scope: "read:user user:email",
  },
};

export const LoginWithOAuthSchema = z.object({
  provider: OAuthProviderSchema,
});

export type LoginWithOAuthSchema = z.infer<typeof LoginWithOAuthSchema>;

export const ExchangeOAuthCodeSchema = z.object({
  provider: OAuthProviderSchema,
  code: z.string().min(1),
});

export type ExchangeOAuthCodeSchema = z.infer<typeof ExchangeOAuthCodeSchema>;
