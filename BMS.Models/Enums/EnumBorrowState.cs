using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Models.Enums
{
    public enum EnumBorrowState
    {
        [Display(Name ="未还书")]
        Not,

        [Display(Name ="已还书")]
        Yes,

        [Display(Name ="逾期")]
        Overdue
    }
}
