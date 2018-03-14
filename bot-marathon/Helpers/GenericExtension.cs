using System;
using System.Collections.Generic;
using System.Linq;

namespace bot_marathon.Helpers
{
    public static class GenericExtension
    {
        public static T SelectRandomdly<T>(this IEnumerable<T> list) => list.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
    }
}