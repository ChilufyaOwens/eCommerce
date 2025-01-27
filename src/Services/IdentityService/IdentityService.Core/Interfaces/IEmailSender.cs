using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(UserId userId);
    }
}
