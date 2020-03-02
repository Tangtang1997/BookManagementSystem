using BMS.Models.Entities.Base;
using BMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Models.Entities
{
    public class BookReturnRecord : Entity<int>
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        public int BorrowId { get; set; }
        
        [ForeignKey("BorrowId")]
        public virtual Book Book { get; set; }

        /// <summary>
        /// 借书人姓名
        /// </summary>
        public string BorrowerName { get; set; }

        /// <summary>
        /// 借书时间
        /// </summary>
        public DateTime? BorrowDate { get; set; }

        /// <summary>
        /// 还书时间
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// 借书状态
        /// </summary>
        public EnumBookState BorrowState { get; set; }
    }
}
