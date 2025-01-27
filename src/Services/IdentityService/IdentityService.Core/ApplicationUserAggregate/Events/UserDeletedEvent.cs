using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.ApplicationUserAggregate.Events
{
    public sealed class UserDeletedEvent(UserId userId) : DomainEventBase
    {
        public UserId UserId { get; init; } = userId;
    }
}
