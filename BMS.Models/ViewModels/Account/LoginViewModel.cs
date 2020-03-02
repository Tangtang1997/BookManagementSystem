using System.ComponentModel.DataAnnotations;

namespace BMS.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required(ErrorMessage = "账号不能为空！")]
        [Display(Name = "账号")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "登录名不能为空！")]
        [Display(Name = "密码")]
        public string PassWord { get; set; }
    }
}