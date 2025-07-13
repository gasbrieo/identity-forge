import react from "@vitejs/plugin-react-swc";
import { defineConfig } from "vite";
import tsConfigPaths from "vite-tsconfig-paths";

export default defineConfig({
  server: {
    port: 3000,
  },
  plugins: [
    react(),
    tsConfigPaths({
      projects: ["./tsconfig.app.json"],
    }),
  ],
});
