import { Link } from "@tanstack/react-router";

import { ModeToggle } from "~/components/mode-toggle";
import { Button } from "~/components/ui/button";

export const LandingPage = () => {
  return (
    <main className="bg-background min-h-screen">
      <header className="w-full border-b border-border bg-background">
        <div className="mx-auto flex h-16 max-w-5xl items-center justify-between px-6">
          <div className="text-xl font-bold">IdentityForge</div>
          <nav>
            <ul className="flex items-center gap-1 text-sm font-medium">
              <li>
                <Button variant="ghost" asChild>
                  <Link to="/auth/login">Log in</Link>
                </Button>
              </li>
              <li>
                <Button variant="ghost" asChild>
                  <Link to="/auth/register">Sign up</Link>
                </Button>
              </li>
              <li>
                <ModeToggle />
              </li>
            </ul>
          </nav>
        </div>
      </header>
      <section className="mx-auto max-w-5xl px-6 py-24">
        <div className="max-w-3xl">
          <h1 className="text-4xl md:text-5xl font-bold mb-6 leading-tight">
            IdentityForge is a purpose-built tool for secure authentication
          </h1>

          <p className="text-muted-foreground text-lg mb-8">
            Meet the system for modern identity management. Streamline login, OAuth providers, and user access in
            minutes.
          </p>

          <Button asChild>
            <Link to="/dashboard">Start building</Link>
          </Button>
        </div>
      </section>
    </main>
  );
};
