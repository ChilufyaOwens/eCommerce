using Ardalis.Specification;
using IdentityService.Core.ApplicationUserAggregate.ValueObjects;

namespace IdentityService.Core.ApplicationUserAggregate.Specifications
{
    public class ApplicationUserByIdSpec : Specification<ApplicationUser>
    {
        public ApplicationUserByIdSpec(UserId userId) => Query.Where(x => x.Id == userId);

    }
}
