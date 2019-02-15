using System.Web.Mvc;

namespace KhMedium.Areas.Guest
{
    public class GuestAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Guest";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Guest_default",
                "Guest/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}