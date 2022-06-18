namespace GiftSender.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GiftSender.Infrastructure.Extensions;
    using GiftSender.Models.Transactions;
    using GiftSender.Models.Users;
    using GiftSender.Services.Transactions;
    using GiftSender.Services.Users;
    using Microsoft.AspNetCore.Authorization;

    using static Areas.Admin.AdminConstants;
    public class TransactionsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ITransactionsService transactionsService;

        public TransactionsController(IUsersService usersService,
                                      ITransactionsService transactionsService)
        {
            this.usersService = usersService;
            this.transactionsService = transactionsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var userId = this.User.Id();
            return this.View(new TransactionFormModel
            {
                Users = this.usersService.GetAll<AllUsersModel>(),
                CurrentCredits = this.usersService.GetUserCreditsById(userId),
                SenderId = userId,
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TransactionFormModel transaction)
        {
            if (!this.usersService.UserExists(transaction.ReceiverId))
            {
                this.ModelState.AddModelError(nameof(transaction.ReceiverId), "Receiver does not exist.");
            }
            var userId = this.User.Id();

            var currentCredits = this.usersService.GetUserCreditsById(userId);

            if (!this.transactionsService.IsPossibleTransaction(currentCredits, transaction.Credits))
            {
                this.ModelState.AddModelError(nameof(transaction.CurrentCredits), "You don't have enough credit.");
            }
            if (userId == transaction.ReceiverId)
            {
                this.ModelState.AddModelError(nameof(transaction.ReceiverId), "You cannot send credits to yourself.");
            }


            if (!ModelState.IsValid)
            {
                return this.View(new TransactionFormModel
                {
                    Users = this.usersService.GetAll<AllUsersModel>(),
                    CurrentCredits = currentCredits,
                    SenderId = userId,
                });
            }

            await this.transactionsService.Create(userId, transaction.ReceiverId, transaction.Massage, transaction.Credits);

            this.TempData["Message"] = "Тhe transaction is completed.";

            return this.RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Info(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var userId = this.User.Id();
            var viewModel = new TransactionsListUserInfo
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.transactionsService.GetTransactionsCountByUserId(userId),
                UserCredits = this.usersService.GetUsersCreditsById<UserCredits>(userId),
                Transactions = this.transactionsService.GetAllTransactionsByUserId<TransactionDTO>(userId, id, ItemsPerPage),
                Action = nameof(Info),
            };
            return this.View(viewModel);

        }
    }
}
