namespace GiftSender.Models.Transactions
{
    public class TransactionsListViewModel : PagingViewModel
    {
        public IEnumerable<TransactionInListViewModel> Transactions { get; set; }
    }
}
