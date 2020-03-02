using System.ComponentModel.DataAnnotations;

namespace BMS.Models.Enums
{
    public enum EnumGender
    {
        [Display(Name = "男")]
        Man,

        [Display(Name = "女")]
        Woman,

        [Display(Name = "未知")]
        UKnown
    }
}