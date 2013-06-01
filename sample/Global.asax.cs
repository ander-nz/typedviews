using System;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Arraybracket.TypedViews.Sample {
	public class Global : HttpApplication {
		protected void Application_Start(object sender, EventArgs args) {
			RouteTable.Routes.MapRoute("GeneralRoute", "{action}", new { controller = "General", action = "Home" });
		}
	}
}