namespace Pandora.Application.Business.Authentication.Results
{
    public record UserAuthenticatedResult(string Token, string Username, string FullName);
}
