﻿using System.Web;
using System.Web.Mvc;

namespace WebIncidencias_UF3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
