using IdentityForge.Application.Messaging;

namespace IdentityForge.Application.Features.Auth.LoginWithEmail;

public sealed record LoginWithEmailCommand(string Email, string Password) : ICommand<AuthResponse>;
