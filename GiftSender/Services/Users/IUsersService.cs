namespace GiftSender.Services.Users
{
    using GiftSender.Data.Models;

    public interface IUsersService
    {
        IEnumerable<T> GetAllWithPaging<T>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetUsersCreditsById<T>(string id);

        double GetUserCreditsById(string id);

        ApplicationUser GetUserById(string id);

        IEnumerable<T> GetAll<T>(int? count = null);

        bool UserExists(string receiverId);

        //IEnumerable<T> GetAllReceiveTransactionWithPaging<T>(string userId, int page, int itemsPerPage = 12);

        int GetCountToReceiveTransaction(string userId);
    }
}
