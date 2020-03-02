using BMS.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Models.Entities
{
    public class LibraryEntryForm : Entity<int>
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        public int StockId { get; set; }

        [ForeignKey("StockId")]
        public virtual Book Book { get; set; }

        /// <summary>
        /// 入库书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? StockDate { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int StockQuantity { get; set;}
    }
}
