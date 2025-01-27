using IdentityService.Core.ApplicationUserAggregate.Events;
using Microsoft.Extensions.Logging;

namespace IdentityService.Core.ApplicationUserAggregate.Handlers
{
    internal class UserDeletedEventHandler(ILogger<UserDeletedEventHandler> logger) : INotificationHandler<UserDeletedEvent>
    {
       

        public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling User deleted event for {userId}", notification.UserId.Value);
        }
    }
}
