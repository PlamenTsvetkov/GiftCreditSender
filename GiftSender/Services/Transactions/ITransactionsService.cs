namespace GiftSender.Services.Transactions
{
    public interface ITransactionsService
    {
        bool IsPossibleTransaction(double senderCredits, double sendCredits);

        Task Create(string senderId, string receiverId, string massage, double credits);

        IEnumerable<T> GetAllWithPaging<T>(int page, int itemsPerPage = 12);

        int GetCount();

    }
}

