using System.Web.Mvc;

namespace BMS.Migatior.ExtensionMethods.Html
{
    public static class HtmlHelperExtensions
    {  
        public static string IsActive(this HtmlHelper html, string controller = null, string action = null)
        {
            const string activeClass = "active"; 
            
            var actualAction = html.ViewContext.RouteData.Values["action"] as string;
            var actualController = html.ViewContext.RouteData.Values["controller"] as string;

            if (string.IsNullOrEmpty(controller))
                controller = actualController;

            if (string.IsNullOrEmpty(action))
                action = actualAction;

            return controller?.ToLower() == actualController?.ToLower() && action?.ToLower() == actualAction?.ToLower() 
                ? activeClass
                : string.Empty;
        }
    }
}