using Ardalis.SmartEnum;

namespace IdentityService.Core.ApplicationUserAggregate.Enums
{
    public class Gender : SmartEnum<Gender>
    {
        public static readonly Gender Male = new(nameof(Male), 1);

        public static readonly Gender Female = new(nameof(Female), 2);

        public static readonly Gender NotSet = new(nameof(NotSet), 3);
        protected Gender(string name, int value) : base(name, value) { }
    }
}
