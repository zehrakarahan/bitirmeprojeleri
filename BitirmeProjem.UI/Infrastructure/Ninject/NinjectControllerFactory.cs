using System;
using System.Web.Mvc;
using System.Web.Routing;
using BitirmeProjem.Business.DependencyResolvers.Ninject;
using Ninject;

namespace BitirmeProjem.UI.Infrastructure.Ninject
{
    public class NinjectControllerFactory :DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel(new BusinessModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}