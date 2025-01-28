namespace IdentityService.Application.ApplicationUsers.Commands.Create
{
    /// <summary>
    /// Command to create a new application user.
    /// </summary>
    /// <param name="FirstName">The first name of the user.</param>
    /// <param name="LastName">The last name of the user.</param>
    /// <param name="PhoneNumber">The phone number of the user.</param>
    /// <param name="UserName">The username of the user.</param>
    /// <param name="Email">The email address of the user.</param>
    /// <param name="Password">The password for the user account.</param>
    public record CreateApplicationUserCommand(
        string FirstName,
        string LastName,
        string? PhoneNumber,
        string UserName,
        string Email,
        string Password,
        string Gender
    ) : ICommand<Result<UserId>>;
}

