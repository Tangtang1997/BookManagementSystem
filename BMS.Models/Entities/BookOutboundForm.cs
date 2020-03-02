using BMS.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Models.Entities
{
    public class BookOutboundForm:Entity<int>
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        public int StockRemovalId { get; set; }

        [ForeignKey("StockRemovalId")]
        public virtual Book Book { get; set; }
        /// <summary>
        /// 出库书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime? StockRemovalDate { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int StockRemovalQuantity { get; set; }
    }
}
