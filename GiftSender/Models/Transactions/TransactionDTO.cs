namespace GiftSender.Models.Transactions
{
    public class TransactionDTO
    {
        public string Id { get; init; }

        public DateTime CreatedOn { get; set; }

        public double Credits { get; set; }

        public string SenderId { get; set; }

        public string  SenderName { get; set; }

        public string ReceiverId { get; set; }

        public string ReceiverName { get; set; }

        public string Massage { get; set; }
    }
}
