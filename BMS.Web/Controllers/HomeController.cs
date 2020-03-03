using System.Threading.Tasks;
using System.Web.Mvc;
using BMS.BLL.DomainService.Users;

namespace BMS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<ActionResult> Index()
        {

            var result =await _userService.GetAllAsync();

            return View();
        }

    }
}
