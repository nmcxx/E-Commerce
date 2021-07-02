using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Helper
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPageOfIndex { get; private set; }
        public int LastPageOfIndex { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            StartPageOfIndex = CheckStartPageOfIndex(pageIndex, pageSize);
            LastPageOfIndex = CheckEndPageOfIndex(pageIndex, pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousFirstPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextEndPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        private int CheckStartPageOfIndex(int pageIndex, int pageSize)
        {
            int result;
            if (pageIndex - 1 <= 0)
            {
                result = pageIndex;
            }
            else
            {
                result = pageIndex - 1;
            }


            int checkStartPageByTotalPages = TotalPages - (pageSize - 1);
            if (checkStartPageByTotalPages >= result || checkStartPageByTotalPages <= 0)
                return result;
            return checkStartPageByTotalPages;
        }

        private int CheckEndPageOfIndex(int pageIndex, int pageSize)
        {
            int result;
            if (pageIndex == 1)
            {
                result = pageSize;
            }
            else
            {
                result = pageIndex + pageSize - 2;
            }


            return result < TotalPages ? result : TotalPages;

        }

        //public bool HasPreviousPage
        //{
        //    get
        //    {
        //        return (PageIndex > 1);
        //    }
        //}

        //public bool HasNextPage
        //{
        //    get
        //    {
        //        return (PageIndex < TotalPages);
        //    }
        //}

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

    }
}
