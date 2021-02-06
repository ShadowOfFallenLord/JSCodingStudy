using System.Web.Mvc;

namespace JSCodingStudy.Areas.Robot
{
    public class RobotAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Robot";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Robot_default",
                "Robot/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}