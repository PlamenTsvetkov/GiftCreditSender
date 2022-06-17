namespace GiftSender.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Transaction;
    public class Transaction
    {
        public Transaction()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        [Required]
        public string Id { get; init; }

        public DateTime CreatedOn { get; set; }

        public double Credits { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }

        [MaxLength(MassageMaxLength)]
        public string Massage { get; set; }
    }
}
