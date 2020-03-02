using BMS.Models.Entities.Base;
using BMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Models.Entities
{
    public class Book : Entity<int>
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 图书类型
        /// </summary>
        public string BookType { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        public string Press { get; set; }

        /// <summary>
        /// 出版日期
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// 图书库存状态
        /// </summary>
        public EnumBookState State { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }

        
    } 
}
