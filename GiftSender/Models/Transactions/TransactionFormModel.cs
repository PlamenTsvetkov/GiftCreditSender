namespace GiftSender.Models.Transactions
{
    using GiftSender.Models.Users;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Transaction;
    public class TransactionFormModel
    {
        [Required]
        [Display(Name = "Mobile Number")]
        public string ReceiverId { get; init; }

        public string SenderId { get; init; }

        [Required]
        [StringLength(MassageMaxLength, MinimumLength = MassageMinLength, ErrorMessage = "{0} must be between {2} and {1} characters long")]
        public string Massage { get; init; }

        [Range(CreditsMin, CreditsMax)]
        public double Credits { get; init; }

        public IEnumerable<AllUsersModel> Users { get; set; }

        public  double CurrentCredits { get; set; }
    }
}
