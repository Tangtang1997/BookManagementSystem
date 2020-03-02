using System.ComponentModel.DataAnnotations;

namespace BMS.BLL.DomainService.Account.Dto
{
    public class LoginInput
    {
        public int Id { get; set; }
        [Display(Name = "登录名")]
        [Required(ErrorMessage = "登录名不得为空")]
        public string LoginName { get; set; } 

        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string PassWord { get; set; }

        public string ReturnUrl { get; set; }
    }
}