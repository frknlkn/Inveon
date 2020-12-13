using Autofac;
using Inveon.DataAccess.Concrete; 
using Inveon.DataAccess.Interfaces;
using System.Data.Entity;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.Business.DependencyResolver.AutofacIOC.Modules
{
    public class EfModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InveonEntities>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
