using LightInject;
using Model.Auth;
using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationUserRole>>((x) => new Repository<ApplicationUserRole>(ambientDbContextLocator));
            container.Register<IRepository<Devoluciones>>((x) => new Repository<Devoluciones>(ambientDbContextLocator));
            container.Register<IRepository<Solicitudes>>((x) => new Repository<Solicitudes>(ambientDbContextLocator));

            container.Register<IDevolucionService, DevolucionService>();
            container.Register<IUsuarioService, UsuarioService>();
            container.Register<ISolicitudService, SolicitudService>();
        }
    }
}
