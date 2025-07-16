export type OAuthProvider = "google" | "github";

export interface OAuthProviderConfig {
  authUrl: string;
  clientId: string;
  scope: string;
}

export interface LoginWithEmailRequest {
  email: string;
}

export interface LoginWithOAuthRequest {
  provider: OAuthProvider;
}

export interface ExchangeOAuthCodeRequest {
  provider: OAuthProvider;
  code: string;
}

export interface AuthResponse {
  email: string;
  name: string;
  avatarUrl: string;
  user: {};
  token: string;
}

export const OAUTH_PROVIDERS: Record<OAuthProvider, OAuthProviderConfig> = {
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
