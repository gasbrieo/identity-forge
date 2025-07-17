using IdentityForge.Application.Messaging;

namespace IdentityForge.Application.Features.Auth.OAuth.ExchangeOAuthCode;

public sealed record ExchangeOAuthCodeCommand(OAuthProvider Provider, string Code) : ICommand<AuthResponse>;
