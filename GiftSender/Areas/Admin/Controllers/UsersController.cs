namespace GiftSender.Areas.Admin.Controllers
{
    using GiftSender.Models.Users;
    using GiftSender.Services.Users;
    using Microsoft.AspNetCore.Mvc;

    using static AdminConstants;
    public class UsersController : AdminController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult All(int id = 1)
        {

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new UsersListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.usersService.GetCount(),
                Users = this.usersService.GetAllWithPaging<UserInListViewModel>(id, ItemsPerPage),
                Action = nameof(All),
            };
            return this.View(viewModel);
        }
    }
}
