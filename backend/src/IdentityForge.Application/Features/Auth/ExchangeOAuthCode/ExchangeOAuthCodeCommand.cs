using IdentityForge.Application.Identity.OAuth;
using IdentityForge.Application.Messaging;

namespace IdentityForge.Application.Features.Auth.ExchangeOAuthCode;

public sealed record ExchangeOAuthCodeCommand(OAuthProvider Provider, string Code) : ICommand<AuthResponse>;
