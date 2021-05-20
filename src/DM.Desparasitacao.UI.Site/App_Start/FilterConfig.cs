using System.Web;
using System.Web.Mvc;
using DM.Desparasitacao.CrossCutting.Filters;

namespace DM.Desparasitacao.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
