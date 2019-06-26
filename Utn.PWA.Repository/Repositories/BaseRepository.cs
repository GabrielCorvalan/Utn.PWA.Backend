using Utn.PWA.Entity.Models;

namespace Utn.PWA.Repository.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly Utn_SysContext ctx;

        public BaseRepository(Utn_SysContext context)
        {
            ctx = context;
        }
    }
}