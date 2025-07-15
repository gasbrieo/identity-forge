/// <reference types="vite/client" />

interface ImportMetaEnv {
  VITE_OAUTH_GITHUB_CLIENT_ID: string;
  VITE_OAUTH_GOOGLE_CLIENT_ID: string;
  VITE_OAUTH_REDIRECT_URL: string;
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}
