using System.Text.Json.Serialization;

namespace IdentityForge.Web.Endpoints.V1;

internal sealed class ExchangeGoogleCodeEndpoint : IApiV1Endpoint
{
    public record Request(string Code);

    public record GoogleTokenResponse(
        [property: JsonPropertyName("access_token")] string AccessToken,
        [property: JsonPropertyName("id_token")] string IdToken
    );

    public record GoogleUserInfo(string Email, string Name, string Picture);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/google/exchange", async (
            Request request,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            CancellationToken cancellationToken) =>
        {
            var http = httpClientFactory.CreateClient();

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "code", request.Code },
                { "client_id", configuration["Google:ClientId"]! },
                { "client_secret", configuration["Google:ClientSecret"]! },
                { "redirect_uri", "http://localhost:3000/auth/callback" },
                { "grant_type", "authorization_code" }
            });

            var response = await http.PostAsync("https://oauth2.googleapis.com/token", content);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadFromJsonAsync<GoogleTokenResponse>()!;

            var response2 = await http.GetAsync($"https://www.googleapis.com/oauth2/v2/userinfo?access_token={tokenResponse.AccessToken}");
            response2.EnsureSuccessStatusCode();

            var userInfo = await response2.Content.ReadFromJsonAsync<GoogleUserInfo>()!;

            var user = new
            {
                Email = userInfo.Email,
                Name = userInfo.Name,
                Avatar = userInfo.Picture
            };

            var appToken = Guid.NewGuid().ToString();

            return Results.Ok(new
            {
                user,
                token = appToken
            });
        });
    }
}
