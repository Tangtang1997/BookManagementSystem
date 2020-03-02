using System.Collections;
using System.Collections.Generic;
using Webdiyer.WebControls.Mvc;

namespace BMS.Models.ViewModels.BaseResponse
{
    public class PageResponse<T> : IPagedList<T>
    {
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }

        public List<T> List { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}