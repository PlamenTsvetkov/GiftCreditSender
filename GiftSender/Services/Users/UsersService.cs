namespace GiftSender.Services.Users
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using GiftSender.Data;
    using GiftSender.Data.Models;

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

        public T GetUsersCreditsById<T>(string id)
        {
            var credits = this.db.Users
                            .Where(u => u.Id == id)
                            .ProjectTo<T>(this.mapper.ConfigurationProvider)
                            .FirstOrDefault();
            return credits;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<ApplicationUser> query =
            this.db.Users
            .OrderBy(x => x.MobileNumber);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.ProjectTo<T>(this.mapper.ConfigurationProvider).ToList();
        }


        public double GetUserCreditsById(string id)
        {
            var credits = this.db.Users
              .Where(u => u.Id == id)
                          .Select(u => u.Credits)
                          .FirstOrDefault();
            return credits;
        }

        public bool UserExists(string receiverId)
        {
            return this.db.Users
                        .Any(c => c.Id == receiverId);
        }

        public ApplicationUser GetUserById(string id)
        {
            return this.db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
