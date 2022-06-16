namespace GiftSender.Services.Users
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GiftSender.Data;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public UsersService(ApplicationDbContext db,
                            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public int GetCount()
        {
            return this.db.Users.Count();
        }

        public IEnumerable<T> GetAllWithPaging<T>(int page, int itemsPerPage = 12)
        {
            var users = this.db.Users
                            .OrderByDescending(x => x.Id)
                            .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                            .ProjectTo<T>(this.mapper.ConfigurationProvider)
                            .ToList();
            return users;
        }

        public T GetUserCreditsById<T>(string id)
        {
            var credits = this.db.Users
                .Where(u => u.Id == id)
                            .ProjectTo<T>(this.mapper.ConfigurationProvider)
                            .FirstOrDefault();
            return credits;
        }
    }
}
