using System.Diagnostics.CodeAnalysis;
using Application.Shared.Repositories;
using Application.Shared.Repositories.Interfaces;
using Autofac;

namespace Application.Shared.AutofacModules
{
    [ExcludeFromCodeCoverage]
    public class ModuleApplication : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //_ = builder.Register(container =>
            //{
            //    var dataBaseOptions = container.Resolve<IOptionsSnapshot<DatabaseOptions>>();
            //    var logger = container.Resolve<ILogger<PetsRepository>>();

            //    return new PetsRepository(new SqlConnection(dataBaseOptions.Value.ConnectionString), logger);
            //}).As<IPetsRepository>();

            //_ = builder.Register(container =>
            //{
            //    var logger = container.Resolve<ILogger<ReceiveObserver>>();
            //    var publish = container.Resolve<PublishService>();

            //    return new ReceiveObserver(logger, publish);
            //}).As<IReceiveObserver>();

            // Singleton para a factory de conexões (usa IConfiguration internamente)
            builder.RegisterType<DbConnectionFactory>()
                   .As<IDbConnectionFactory>()
                   .SingleInstance();

            // BaseRepository genérico por escopo
            builder.RegisterGeneric(typeof(BasePostgresRepository<>))
                   .As(typeof(IBaseRepository<>))
                   .InstancePerLifetimeScope();


        }
    }
}

