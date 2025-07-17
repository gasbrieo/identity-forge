import { useMutation } from "@tanstack/react-query";
import { createFileRoute, Link, redirect } from "@tanstack/react-router";
import { AlertCircleIcon, CheckCircle2Icon, ShieldIcon } from "lucide-react";

import { Alert, AlertDescription } from "~/components/ui/Alert";
import { useAppForm } from "~/components/ui/Form";
import { Input } from "~/components/ui/Input";
import { SendMagicLinkSchema } from "~/schemas/auth.schemas";
import { sendMagicLink } from "~/services/auth.service";

const SendMagicLinkPage = () => {
  const mutation = useMutation({
    mutationFn: sendMagicLink,
  });

  const form = useAppForm({
    validators: { onChange: SendMagicLinkSchema },
    defaultValues: {
      email: "",
    },
    onSubmit: ({ value }) => {
      mutation.mutate({
        email: value.email,
      });
    },
  });

  return (
    <main className="flex min-h-screen flex-col items-center justify-center bg-background px-4">
      <div className="flex flex-col items-center gap-4 text-center">
        <ShieldIcon className="h-10 w-10 text-primary" />
        <h1 className="text-xl font-semibold">Log in with Magic Link</h1>
        <p className="text-sm text-muted-foreground">Enter your email and we&apos;ll send you a secure login link.</p>
      </div>

      <form
        onSubmit={(e) => {
          e.preventDefault();
          e.stopPropagation();
          form.handleSubmit();
        }}
        className="mt-8 flex w-full max-w-xs flex-col gap-3"
      >
        <div className="grid gap-6">
          <form.AppField name="email">
            {(field) => (
              <field.FormItem>
                <field.FormLabel>Email</field.FormLabel>
                <field.FormControl>
                  <Input
                    type="email"
                    name={field.name}
                    value={field.state.value}
                    onBlur={field.handleBlur}
                    onChange={(e) => field.handleChange(e.target.value)}
                  />
                </field.FormControl>
                <field.FormMessage />
              </field.FormItem>
            )}
          </form.AppField>

          {mutation.isError && (
            <Alert variant="destructive">
              <AlertCircleIcon />
              <AlertDescription>{mutation.error.message}</AlertDescription>
            </Alert>
          )}

          {mutation.isSuccess && (
            <Alert variant="default">
              <CheckCircle2Icon />
              <AlertDescription>We&apos;ve sent a magic login link to your email. Click it to log in.</AlertDescription>
            </Alert>
          )}

          {!mutation.isSuccess && (
            <form.AppForm>
              <form.SubmitButton isLoading={mutation.isPending}>Send Magic Link</form.SubmitButton>
            </form.AppForm>
          )}

          <div className="text-sm">
            <Link className="hover:underline underline-offset-4" to="/auth/login">
              Back to Login
            </Link>
          </div>
        </div>
      </form>
    </main>
  );
};

export const Route = createFileRoute("/auth/magic-link/send")({
  beforeLoad: ({ context }) => {
    if (context.auth.isAuthenticated) {
      throw redirect({ to: "/dashboard" });
    }
  },
  component: SendMagicLinkPage,
});
