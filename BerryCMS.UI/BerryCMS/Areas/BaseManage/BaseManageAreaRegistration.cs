using System.Web.Mvc;

namespace BerryCMS.Areas.BaseManage
{
    public class BaseManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BaseManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                this.AreaName + "_Default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { area = this.AreaName, controller = "Login", action = "Index", id = UrlParameter.Optional },
                new string[] { "BerryCMS.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}