using Ardalis.GuardClauses;
using IdentityService.Core.ApplicationUserAggregate.Enums;
using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.ApplicationUserAggregate
{
    /// <summary>
    /// Represents an application user.
    /// </summary>
    public sealed class ApplicationUser : EntityBase<UserId>, IAggregateRoot
    {
        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public UserName UserName { get; private set; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public EmailAddress Email { get; private set; }

        /// <summary>
        /// Gets the password of the user.
        /// </summary>
        public Password Password { get; private set; }

        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        public string FirstName { get; private set; } = default!;

        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        public string LastName { get; private set; } = default!;

        /// <summary>
        /// Gets the phone number of the user.
        /// </summary>
        public string? PhoneNumber { get; private set; }

        /// <summary>
        /// Gets the gender of the user.
        /// </summary>
        public Gender Gender { get; private set; } = Gender.NotSet;


        /// <summary>
        /// Sets the password of the user.
        /// </summary>
        /// <param name="password">The password to set.</param>
        public void SetPassword(string password)
        {
            Password = Password.From(Guard.Against.NullOrEmpty(password, nameof(password)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="phoneNumber">The phone number of the user.</param>
        /// <param name="userName">The username of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="gender">The gender of the user.</param>
        private ApplicationUser(
            UserId userId,
            string firstName,
            string lastName,
            string? phoneNumber,
            UserName userName,
            EmailAddress email,
            Password password,
            Gender gender)
        {
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            PhoneNumber = phoneNumber;
            UserName = userName;
            Email = email;
            Password = password;
            Gender = gender;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="phoneNumber">The phone number of the user.</param>
        /// <param name="userName">The username of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="gender">The gender of the user.</param>
        /// <returns>A new instance of the <see cref="ApplicationUser"/> class.</returns>
        public static ApplicationUser Create(
            string firstName,
            string lastName,
            string? phoneNumber,
            UserName userName,
            EmailAddress email,
            Password password,
            Gender gender)
        {
            return new ApplicationUser(
                UserId.From(Guid.NewGuid()),
                firstName,
                lastName,
                phoneNumber,
                userName,
                email,
                password,
                gender);
        }
    }
}
