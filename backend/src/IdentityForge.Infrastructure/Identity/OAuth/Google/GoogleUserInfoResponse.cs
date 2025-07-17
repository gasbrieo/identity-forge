namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

public sealed class GoogleUserInfoResponse
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("picture")]
    public string Picture { get; set; } = default!;
};
