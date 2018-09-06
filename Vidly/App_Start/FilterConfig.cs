using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //vyzaduje autentifikaciu v celej aplikacii 
            filters.Add(new RequireHttpsAttribute()); //zabezpeci ze web app bude dostupna len s https
        }
    }
}
