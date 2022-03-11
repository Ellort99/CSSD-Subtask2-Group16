using System.Web;
using System.Web.Mvc;

namespace CSSD_Subtask2_Group16
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
