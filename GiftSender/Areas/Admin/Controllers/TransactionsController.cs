namespace GiftSender.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GiftSender.Models.Transactions;
    using GiftSender.Services.Transactions;

    using static AdminConstants;
    public class TransactionsController : AdminController
    {
        private readonly ITransactionsService transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            this.transactionsService = transactionsService;
        }
        public IActionResult All(int id = 1)
        {

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new TransactionsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.transactionsService.GetCount(),
                Transactions = this.transactionsService.GetAllWithPaging<TransactionInListViewModel>(id, ItemsPerPage),
                Action = nameof(All),
            };
            return this.View(viewModel);
        }
    }
}
