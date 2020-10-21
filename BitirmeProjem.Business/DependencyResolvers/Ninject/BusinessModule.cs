using System.Reflection;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace BitirmeProjem.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
            {
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .BindAllInterfaces()
                    .Configure(t => t.InSingletonScope());

                x.From(Assembly.Load("BitirmeProjem.DataAccess"))
                    .SelectAllClasses()
                    .BindAllInterfaces()
                    .Configure(t => t.InSingletonScope());

            });
        }
    }
}
