namespace Pandora.Application.Dto.Authentication.Requests
{
    public record RegisterNewUserRequest( 
        string Username,
        string Password,
        string ConfirmedPassword,
        string Email,
        string Name,
        string LastName
    );
}
