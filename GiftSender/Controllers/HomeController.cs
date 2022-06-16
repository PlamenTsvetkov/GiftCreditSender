namespace GiftSender.Controllers
{
    using GiftSender.Infrastructure.Extensions;
    using GiftSender.Models;
    using GiftSender.Models.Users;
    using GiftSender.Services.Users;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService usersService;

        public HomeController(ILogger<HomeController> logger,
            IUsersService usersService)
        {
            _logger = logger;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            
    //        if (this.User.Id() == null)
    //        {
    //            return RedirectToAction("Account", "Login", new { area = "Identity" });
    //}
    //        string userId = this.User.Id();
    //        var credits =usersService.GetUserCreditsById<UserCredits>(userId);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}