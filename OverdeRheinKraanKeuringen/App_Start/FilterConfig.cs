﻿using System.Web.Mvc;

namespace OverdeRheinKraanKeuringen
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}