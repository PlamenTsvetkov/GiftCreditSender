namespace GiftSender.Services.Users
{
    public interface IUsersService
    {
        IEnumerable<T> GetAllWithPaging<T>(int page, int itemsPerPage = 12);

        int GetCount();
        T GetUserCreditsById<T>(string id);
    }
}
