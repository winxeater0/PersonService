using Autofac;
using imobiSystem.Application;
using imobiSystem.Application.Mapping;
using imobiSystem.Infrastructure.Data.Repositories;
using PersonService.Application.Interfaces;
using PersonService.Application.Interfaces.Mapping;
using PersonService.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace PersonService.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<PersonManager>().As<IPersonManager>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<PersonMapper>().As<IPersonMapper>();

            #endregion
        }
    }
}
