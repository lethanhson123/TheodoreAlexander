using System.Configuration;
using System.Web.Http;
using TA_Web_2020_API.Helper;

namespace TA_Web_2020_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //remove when upload to product env
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            HttpConfiguration config = GlobalConfiguration.Configuration;

            //var enabledAutoSendEmail = ConfigurationManager.AppSettings["EnableAutoSendEmail"];
            //if(!string.IsNullOrEmpty(enabledAutoSendEmail) && enabledAutoSendEmail != "0")
            //{
            //    JobScheduler.Start().GetAwaiter().GetResult();
            //}
            //else
            //{
            //    JobScheduler.End().GetAwaiter().GetResult();
            //}
        }
        //protected void Application_End()
        //{
        //    JobScheduler.End().GetAwaiter().GetResult();
        //}
    }
}
