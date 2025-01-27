using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.ApplicationUserAggregate.Events
{
    public sealed class UserCreatedEvent : DomainEventBase
    {
        public UserCreatedEvent(UserId userId, string firstName, string lastName, string? phoneNumber)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public UserId UserId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? PhoneNumber { get; init; }

    }
}
