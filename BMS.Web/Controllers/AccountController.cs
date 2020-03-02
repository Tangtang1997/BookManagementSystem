using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using BMS.BLL.DomainService.Account;
using BMS.BLL.DomainService.Account.Dto;

namespace BMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginInput loginInput)
        {
            if (!ModelState.IsValid)
            {
                ViewData["StatusMessage"] = "验证失败";
                return View(loginInput);
            }

            var loginResult = await _accountService.IsLoginAsync(loginInput);

            if (!loginResult.IsSucceed)
            {
                ViewBag.ErrorMessage = "用户名或密码错误";
                return View(loginInput);
            }

            FormsAuthentication.SetAuthCookie(loginInput.LoginName, false);
            Session["user"] = loginResult.User;

            if (!string.IsNullOrWhiteSpace(loginInput.ReturnUrl))
            {
                return Redirect(loginInput.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public void LoginOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Login");
        }
    }
}