using Models;
using Repository.Context;

namespace Repository
{
    public class DispositivosRepository : BaseRepository<Dispositivo>
    {
        public DispositivosRepository(ServerContext context) : base(context) { }
    }
}