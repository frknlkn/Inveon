﻿using System.Web;
using System.Web.Mvc;

namespace Inveon.ADMIN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
