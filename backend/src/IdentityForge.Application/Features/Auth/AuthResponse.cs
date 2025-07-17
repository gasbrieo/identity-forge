namespace IdentityForge.Application.Features.Auth;

public sealed record AuthResponse(string Email, string? Name, string? AvatarUrl, string Token);
