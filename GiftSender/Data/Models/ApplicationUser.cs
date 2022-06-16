namespace GiftSender.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Credits = 100;
        }
        public string Name { get; set; }

        public string MobileNumber { get; set; }
        public double Credits { get; set; }

    }
}
