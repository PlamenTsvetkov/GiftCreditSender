namespace GiftSender.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using GiftSender.Models;
    using GiftSender.Models.Users;
    using GiftSender.Services.Users;
    using GiftSender.Infrastructure.Extensions;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            string userId = this.User.Id();
            var credits = usersService.GetUsersCreditsById<UserCredits>(userId);
            return View(credits);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}