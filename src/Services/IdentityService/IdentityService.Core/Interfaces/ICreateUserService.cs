using Ardalis.Result;

namespace IdentityService.Core.Interfaces
{
    public interface ICreateUserService
    {
        public Task<Result> CreateUser(Guid userId,
            string firstName,
            string lastName,
            String email,
            string password,
            string username,
            string phoneNumber,
            string gender);
    }
}
