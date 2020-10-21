using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BitirmeProjem;
using BitirmeProjem.Business.DependencyResolvers.Ninject;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Areas.Admin.Models.VM;
using BitirmeProjem.UI.Infrastructure.Ninject;
using BitirmeProjem.UI.Models.VM;
using FluentValidation.Mvc;

namespace BitirmeProjem.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidatorFactory();
                provider.AddImplicitRequiredValidator = false;
            });
            Mapper.Initialize(mapping =>
            {
                mapping.CreateMap<Urunler, UrunlerVM>().ReverseMap();
                mapping.CreateMap<Yorumlar, YorumlarVM>().ReverseMap();
                mapping.CreateMap<Kuponlar, KuponlarVM>().ReverseMap();
                mapping.CreateMap<Uyeler, UyeOl>().ReverseMap();
            });
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo cInfo = new CultureInfo("tr-TR");
            cInfo.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = cInfo;
            Thread.CurrentThread.CurrentUICulture = cInfo;
        }
    }
}
