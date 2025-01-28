namespace IdentityService.Application.ApplicationUsers
{
    public record ApplicationUserDto(Guid Id, 
        string UserName, 
        string Email, 
        string FirstName, 
        string LastName, 
        string? FullName, 
        string? PhoneNumber, 
        string Gender);
}
