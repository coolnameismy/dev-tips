using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiosealMVCWeb.Models
{
    public class Pagination
    {
        public int? PageIndex { get; private set; }//当前页号减一的值 
        public int PageSize { get; private set; }　//每页显示的内容数量 
        public int TotalPages { get; private set; }//总页数 
        public int Start { get; private set; }//当前页面，显示的第一个页号（比如在中间的页面，页号显示是9号到16号，9就是Start） 
        public int End { get; private set; }//当前页面，显示的最后一个页号
        public int TotalCount { get; private set; } //总记录数
        public int? Prv { get; private set; }  //上一页页码
        public int? Next { get; private set; } //下一页页码
        public int Curr { get; private set;} //当前页页码
 
        // 为“上一页”“下一页”导航备用 
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
        public Pagination(int? pageIndex, int pageSize, int totalcount)
        {
            TotalPages = totalcount; //总记录数量
            PageIndex = (pageIndex ?? 0); //当前页的索引
            PageSize = pageSize; //每个记录的条数
            TotalPages = (int)Math.Ceiling(totalcount / (double)PageSize); //总共页码数
            int PaginationSize = 10;//页号的显示个数     这里规定每个页面显示10个页号 
            TotalCount = totalcount;
            Prv = pageIndex - 1;
            Next = pageIndex + 1;

            int size;//判定每个页面显示多少个页号 
            if (TotalPages > PaginationSize)
            {
                size = PaginationSize;
                //定义每个页面的页号从几开始 
                if (pageIndex > 2 && pageIndex < TotalPages - (size - 2))
                {
                    Start = (pageIndex ?? 0) - 1;
                }
                else if (pageIndex >= TotalPages - (size - 2))
                {
                    Start = TotalPages - size + 1;
                }
                else
                {
                    Start = 1;
                }
            }
            else
            {
                size = TotalPages;
                Start = 1;

            }

            End = Start + size - 1;
        }
    }
}