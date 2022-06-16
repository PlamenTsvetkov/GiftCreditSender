namespace GiftSender.Areas.Admin.Controllers
{
    using GiftSender.Services.Transactions;
    using GiftSender.Services.Users;
    using GiftSender.Models.Home;
    using Microsoft.AspNetCore.Mvc;

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
