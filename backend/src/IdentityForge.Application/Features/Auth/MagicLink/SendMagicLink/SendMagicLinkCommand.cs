using IdentityForge.Application.Messaging;

namespace IdentityForge.Application.Features.Auth.MagicLink.SendMagicLink;

public sealed record SendMagicLinkCommand(string Email) : ICommand;

