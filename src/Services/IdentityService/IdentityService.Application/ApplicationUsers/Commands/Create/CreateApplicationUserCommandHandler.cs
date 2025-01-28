using IdentityService.Core.ApplicationUserAggregate;
using IdentityService.Core.ApplicationUserAggregate.Enums;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.ApplicationUsers.Commands.Create
{
    /// <summary>
    /// Handles the creation of a new application user.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateApplicationUserCommandHandler"/> class.
    /// </remarks>
    /// <param name="_repository">The repository to interact with the data store.</param>
    /// <param name="_logger">The logger to log information.</param>
    public class CreateApplicationUserCommandHandler(
        IRepository<ApplicationUser> _repository,
        ILogger<CreateApplicationUserCommandHandler> _logger) : ICommandHandler<CreateApplicationUserCommand, Result<UserId>>
    {
       
        /// <summary>
        /// Handles the creation of a new application user.
        /// </summary>
        /// <param name="request">The command containing the user details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result containing the user ID of the created user.</returns>
        public async Task<Result<UserId>> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a new application user.");

            var newApplicationUser = ApplicationUser.Create(
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                UserName.From(request.UserName),
                EmailAddress.From(request.Email),
                Password.From(request.Password),
                Gender.FromName(request.Gender)
            );

            var createdUser = await _repository.AddAsync(newApplicationUser, cancellationToken);

            _logger.LogInformation("Created a new application user with ID {UserId}.", createdUser.Id.Value);

            return Result<UserId>.Success(createdUser.Id);
        }
    }
}
