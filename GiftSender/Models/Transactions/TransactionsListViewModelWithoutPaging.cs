namespace GiftSender.Models.Transactions
{
    using GiftSender.Models.Users;

    public class TransactionsListViewModelWithoutPaging
    {
        public UserCredits UserCredits { get; set; }
        public IEnumerable<TransactionInListViewModel> IncomingTransactions { get; set; }
        public IEnumerable<TransactionInListViewModel> OutcomingTransactions { get; set; }
    }
}
