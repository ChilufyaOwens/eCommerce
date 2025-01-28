using IdentityService.Core.ApplicationUserAggregate;
using IdentityService.Core.ApplicationUserAggregate.Specifications;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.ApplicationUsers.Queries.Get
{
    /// <summary>
    /// Handles the retrieval of an application user by ID.
    /// </summary>
    public class GetApplicationUserQueryHandler(IReadRepository<ApplicationUser> _repository, 
        ILogger<GetApplicationUserQueryHandler> _logger) : IQueryHandler<GetApplicationUserQuery, Result<ApplicationUserDto>>
    {
        /// <summary>
        /// Handles the retrieval of an application user by ID.
        /// </summary>
        /// <param name="request">The query containing the user ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result containing the application user DTO.</returns>
        public async Task<Result<ApplicationUserDto>> Handle(GetApplicationUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving application user with ID {UserId}.", request.userId);

            var userSpec = new ApplicationUserByIdSpec(UserId.From(request.userId));
            var entity = await _repository.FirstOrDefaultAsync(userSpec, cancellationToken);

            if (entity == null)
            {
                _logger.LogWarning("Application user with ID {UserId} not found.", request.userId);
                return Result.NotFound();
            }

            _logger.LogInformation("Application user with ID {UserId} retrieved.", request.userId);

            var userDto = new ApplicationUserDto(
                entity.Id.Value,
                entity.UserName.Value,
                entity.Email.Value,
                entity.FirstName,
                entity.LastName,
                "", // Assuming this is a placeholder for a missing property
                entity.PhoneNumber,
                entity.Gender.Name);

            return Result<ApplicationUserDto>.Success(userDto);
        }
    }
}
