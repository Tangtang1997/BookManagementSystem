using System.Threading.Tasks;
using System.Web.Mvc;
using BMS.BLL.DomainService.Users;
using BMS.Models.ViewModels.CRUD;

namespace BMS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var list = await _userService.GetAllAsync();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _userService.AddAsync(model))
            {
                return RedirectToAction("Index");
            }

            Response.Write("<script>alert('添加失败！');</script>");
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            if (await _userService.UpdateAsync(userViewModel))
            {
                return Json(new { status = true, msg = "删除成功" });
            }

            return View(userViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var userViewModel = await _userService.GetByIdAsync(id);

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {

            if (await _userService.DeleteByIdAsync(id))
            {
                return Json(new { status = true, msg = "删除成功" });
            }

            Response.Write("<script>alert('删除失败！');</script>");
            return RedirectToAction("Index");
        }
    }
}