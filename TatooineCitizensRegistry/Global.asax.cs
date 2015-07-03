using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Configuration;
using Utils;
using System.Web.Configuration;

namespace TatooineCitizensRegistry
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            LogUtil.Log("Application_Start");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ClientSection clientSection = (WebConfigurationManager.GetSection("system.serviceModel/client") as ClientSection);
            foreach (ChannelEndpointElement item in clientSection.Endpoints)
            {
                if (item.Name == "BasicHttpBinding_ITatooineCitizens")
                {
                    Application["WCFurl"] = item.Address.ToString().Replace("/wcf", "");
                }
            }
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = null;
            ex = Server.GetLastError();
            LogUtil.Log("Application_Error", ex);
        }
    }
}