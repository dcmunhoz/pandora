namespace Pandora.Application.Dto.Authentication.Responses
{
    public record UserAuthenticatedResponse(string Token, string Username, string FullName);
}
