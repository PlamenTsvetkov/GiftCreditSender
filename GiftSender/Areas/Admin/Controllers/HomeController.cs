namespace GiftSender.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GiftSender.Services.Transactions;
    using GiftSender.Services.Users;
    using GiftSender.Models.Home;

    public class HomeController : AdminController
    {
        private readonly IUsersService usersService;
        private readonly ITransactionsService transactionsService;

        public HomeController(IUsersService usersService,
                              ITransactionsService transactionsService)
        {
            this.usersService = usersService;
            this.transactionsService = transactionsService;
        }

        public IActionResult Index()
        {

            var viewModel = new IndexAdminViewModel
            {
                UsersNumber = this.usersService.GetCount(),
                TransactionsNumber=this.transactionsService.GetCount(),
            };

            return this.View(viewModel);
        }
    }
}
