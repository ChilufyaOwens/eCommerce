using Ardalis.Result;
using IdentityService.Core.ApplicationUserAggregate;
using IdentityService.Core.ApplicationUserAggregate.Events;
using IdentityService.Core.ApplicationUserAggregate.ValueObjects;
using IdentityService.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace IdentityService.Core.Services
{
    public class DeleteUserService(IRepository<ApplicationUser> _repository, 
        IMediator _mediator, 
        ILogger<DeleteUserService> Logger) : IDeleteUserService
    {
        public async Task<Result> DeleteUser(UserId userId)
        {
            Logger.LogInformation("Deleting user with id {userId}", userId.Value);
            ApplicationUser? aggregateToDelete = await _repository.GetByIdAsync(userId);

            if(aggregateToDelete == null) return Result.NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            await _mediator.Publish(new UserDeletedEvent(userId));

            Logger.LogInformation("User with id {userId} deleted", userId.Value);

            return Result.Success();
        }
    }
}
