import { api } from "~/lib/axios/api";
import {
  OAUTH_PROVIDERS,
  type AuthResponse,
  type ExchangeOAuthCodeRequest,
  type LoginWithOAuthRequest,
} from "~/types/auth.types";

export const loginWithOAuth = (data: LoginWithOAuthRequest) => {
  const redirectUri = `${window.location.origin}/auth/callback`;

  const config = OAUTH_PROVIDERS[data.provider];

  const params = new URLSearchParams({
    client_id: config.clientId,
    redirect_uri: redirectUri,
    response_type: "code",
    scope: config.scope,
    state: data.provider,
  });

  return { url: `${config.authUrl}?${params.toString()}` };
};

export const exchangeOAuthCode = async (data: ExchangeOAuthCodeRequest) => {
  const response = await api.post<AuthResponse>("/api/v1/auth/oauth/exchange", data);
  return response.data;
};
