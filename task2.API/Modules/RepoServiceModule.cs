using Autofac;
using System.Reflection;
using task2.Core.Repositories;
using task2.Core.Services;
using task2.Core.UnitOfWorks;
using task2.Repository;
using task2.Repository.Repositories;
using task2.Repository.UnitOfWorks;
using task2.Service.Mapping;
using task2.Service.Services;
using Module = Autofac.Module;

namespace task2.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssambly = Assembly.GetExecutingAssembly();
            var repoAssambly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssambly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssambly, repoAssambly,serviceAssambly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssambly, repoAssambly, serviceAssambly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
