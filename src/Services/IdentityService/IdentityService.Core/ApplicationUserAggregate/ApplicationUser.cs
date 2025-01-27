
using Ardalis.GuardClauses;
using IdentityService.Core.ApplicationUserAggregate.Enums;
using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.ApplicationUserAggregate
{
    /// <summary>
    /// ApplicationUser class represents the user entity in the system. 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="phoneNumber"></param>
    public class ApplicationUser(
        string firstName, 
        string lastName, 
        string? phoneNumber) : EntityBase<UserId>, IAggregateRoot
    {
        public UserName UserName { get; private set; }
        public EmailAddress Email { get; private set; }
        public Password Password { get; private set; }
        public string FirstName { get; private set; } = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        public string LastName { get; private set; } = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        public string? PhoneNumber { get; private set; } = Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));
        public Gender Gender { get; private set; } = Gender.NotSet;

        public void SetUserName(string userName)
        {
            UserName.TryFrom(Guard.Against.NullOrEmpty(userName, nameof(userName)));
        }

        public void SetEmail(string email)
        {
            EmailAddress.TryFrom(Guard.Against.NullOrEmpty(email, nameof(email)));
        }

        public void SetPassword(string password)
        {
            Password.TryFrom(Guard.Against.NullOrEmpty(password, nameof(password)));
        }

    }

}
