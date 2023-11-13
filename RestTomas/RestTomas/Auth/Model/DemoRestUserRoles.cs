using System.Collections.Generic;

namespace RestTomas.Auth.Model
{
    public static class DemoRestUserRoles
    {
        public const string Admin = nameof(Admin);
        public const string SimpleUser = nameof(SimpleUser);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, SimpleUser };
    }
}