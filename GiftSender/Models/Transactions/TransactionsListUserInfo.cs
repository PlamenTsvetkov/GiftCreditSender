namespace GiftSender.Models.Transactions
{
    using GiftSender.Models.Users;

    public class TransactionsListUserInfo : PagingViewModel
    {
        public UserCredits UserCredits { get; set; }
        public IEnumerable<TransactionDTO> Transactions { get; set; }
    }
}
