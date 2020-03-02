using BMS.Models.Entities.Base;
using BMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models.ViewModels.CRUD
{
    public class UserViewModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Display(Name = "登录名")]
        [Required(ErrorMessage = "登录名不能为空")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        [RegularExpression(@"^\w+$", ErrorMessage = "{0}只能包含数字、字母和下划线")]
        public string PassWord { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Display(Name = "身份证号")]
        [Required(ErrorMessage = "身份证号不能为空"),MaxLengthAttribute(18),MinLength(18)]
        public string IdNumber { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        [Display(Name = "地址")]
        [Required(ErrorMessage = "地址不能为空")]
        public string Address { get; set; }

        [Display(Name="性别")]
        [Required(ErrorMessage ="性别不能为空")]
        public EnumGender Gender { get; set; }

    }
}
