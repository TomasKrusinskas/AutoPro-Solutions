using Microsoft.AspNetCore.Identity;

namespace RestTomas.Data.Dtos.Auth
{
    public class DemoRestUser : IdentityUser
    {
        [PersonalData]
        public string AdditionalInfo { get; set; }
    }
}
 