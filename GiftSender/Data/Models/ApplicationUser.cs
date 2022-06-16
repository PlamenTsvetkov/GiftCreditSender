namespace GiftSender.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.ApplicationUser;
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Credits = 100;
            this.IncomingTransactions = new HashSet<Transaction>();
            this.OutcomingTransactions = new HashSet<Transaction>();
        }
        [Reguired]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Reguired]
        [MaxLength(MobileNumberMaxLength)]
        public string MobileNumber { get; set; }

        public double Credits { get; set; }

        public virtual ICollection<Transaction> IncomingTransactions { get; set; }

        public virtual ICollection<Transaction> OutcomingTransactions { get; set; }

    }
}
