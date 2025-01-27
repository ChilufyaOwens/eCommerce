using IdentityService.Core.ApplicationUserAggregate.Events;
using Microsoft.Extensions.Logging;

namespace IdentityService.Core.ApplicationUserAggregate.Handlers
{
    internal class UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger) : INotificationHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling user created event for {userId}", notification.UserId.Value);

        }
    }

}
