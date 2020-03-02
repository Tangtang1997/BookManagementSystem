using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Models.Enums
{
    public enum EnumBookState
    {
        [Display(Name = "库存无书")]
        Bookless,

        [Display(Name = "库存有书")]
        HaveBook
    }
}
