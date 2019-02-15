using System.Web.Mvc;

namespace KhMedium.Areas.Author
{
    public class AuthorAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Author";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Author_default",
                "Author/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "KhMedium.Areas.Author.Controllers" }

            );
        }
    }
}