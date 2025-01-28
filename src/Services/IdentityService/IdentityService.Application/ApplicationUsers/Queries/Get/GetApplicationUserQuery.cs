namespace IdentityService.Application.ApplicationUsers.Queries.Get
{
    public record GetApplicationUserQuery(Guid userId) : IQuery<Result<ApplicationUserDto>>;

}
