using IdentityForge.Application.Messaging;

namespace IdentityForge.Application.Features.Auth.MagicLink.VerifyMagicLink;

public sealed record VerifyMagicLinkCommand(string Token) : ICommand<AuthResponse>;
