using BMS.Models.Entities.Base;
using BMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models.Entities
{
    public class User : Entity<int>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; } 

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public EnumGender Gender { get; set; } 
    }
}