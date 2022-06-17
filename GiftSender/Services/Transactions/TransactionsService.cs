namespace GiftSender.Services.Transactions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using GiftSender.Data;
    using GiftSender.Data.Models;
    using GiftSender.Services.Users;

    public class TransactionsService : ITransactionsService
    {
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public TransactionsService(IUsersService usersService,
                                   ApplicationDbContext db,
                                   IMapper mapper)
        {
            this.usersService = usersService;
            this.db = db;
            this.mapper = mapper;
        }
        public async Task Create(string senderId, string receiverId, string massage, double credits)
        {
            var sender = this.usersService.GetUserById(senderId);
            var receiver = this.usersService.GetUserById(receiverId);
            sender.Credits -= credits;
            receiver.Credits += credits;
            this.db.SaveChanges();
            var transaction = new Transaction
            {
                Credits = credits,
                Massage = massage,
                ReceiverId = receiverId,
                SenderId = senderId,
            };
            await this.db.Transactions.AddAsync(transaction);
            await this.db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllReceiveTransactionsByUserId<T>(string receiverId)
        {
            var receiveTransactions = this.db.Transactions
                .Where(t => t.ReceiverId == receiverId)
                         .OrderByDescending(x => x.CreatedOn)
                         .ProjectTo<T>(this.mapper.ConfigurationProvider)
                         .ToList();

            return receiveTransactions;
        }

        public IEnumerable<T> GetAllSendTransactionsByUserId<T>(string senderId)
        {
            var sendTransactions = this.db.Transactions
                .Where(t => t.SenderId == senderId)
                         .OrderByDescending(x => x.CreatedOn)
                         .ProjectTo<T>(this.mapper.ConfigurationProvider)
                         .ToList();

            return sendTransactions;
        }

        public IEnumerable<T> GetAllWithPaging<T>(int page, int itemsPerPage = 12)
        {
            var transactions = this.db.Transactions
                         .OrderByDescending(x => x.CreatedOn)
                         .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                         .ProjectTo<T>(this.mapper.ConfigurationProvider)
                         .ToList();
            return transactions;
        }

        public int GetCount()
        {
            return this.db.Transactions.Count();
        }

        public bool IsPossibleTransaction(double senderCredits, double sendCredits)
        {
            return senderCredits >= sendCredits;
        }


    }
}
