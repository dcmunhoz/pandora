namespace Pandora.Application.Business.Authentication.Results
{
    public record UserRegistredResult(
        Guid Id,
        string Username,
        string Email,
        string Name,
        string LastName
    );
}
