using Ardalis.Result;
using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.Interfaces
{
    public interface IDeleteUserService
    {
        public Task<Result> DeleteUser(UserId userId);
    }
}
