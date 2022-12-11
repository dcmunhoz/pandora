namespace Pandora.Application.Dto.Authentication.Responses
{
    public record RegisterNewUserResponse(
        Guid Id,
        string Username,
        string Email,
        string Name,
        string LastName
    );
}
