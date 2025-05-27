using Mess_Management_System.Models;
using Mess_Management_System.Services;
using Mess_Management_System.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Mess_Management_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();
            
            // Register DbContext
            container.RegisterType<ApplicationDbContext>();
            
            // Register Services
            container.RegisterType<IMealService, MealService>();
            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<IPaymentService, PaymentService>();
            container.RegisterType<IMonthlySummaryService, MonthlySummaryService>();
            container.RegisterType<IMealRateService, MealRateService>();
            container.RegisterType<IMarketService, MarketService>();
            container.RegisterType<INoticeService, NoticeService>();

            // Set the dependency resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
