using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPCN.Models
{
    public static class SanPhamKhac
    {
        public static IEnumerable<T> LayNgauNhien<T>(this IEnumerable<T> source , Int32 count)
        {
            return source.OrderBy(s => Guid.NewGuid()).Take(count);
        }
    }
}