using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldTelecomFinal.ViewModels
{
    public class PageNatedList<T> : List<T>
    {
        public PageNatedList(IQueryable<T> query, int page, int pagecount, int itemcount)
        {
            Page = page;
            PageCount = pagecount;
            ItemCount = itemcount;
            HasNext = page < pagecount;
            HasPrev = page > 1;
            this.AddRange(query);
        }

        public int Page { get; }
        public int PageCount { get; }
        public int ItemCount { get; }
        public bool HasNext { get; }
        public bool HasPrev { get; }

        public static PageNatedList<T> Create(IQueryable<T> query, int page, int itemCount)
        {
            int pageCount = (int)Math.Ceiling((decimal)query.Count() / itemCount);

            page = page < 1 || page > pageCount ? 1 : page;

            query = query.Skip((page - 1) * itemCount).Take(itemCount);

            return new PageNatedList<T>(query, page, pageCount, itemCount);
        }
    }
}
