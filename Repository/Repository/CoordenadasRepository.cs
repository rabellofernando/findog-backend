using Models;
using Repository.Context;

namespace Repository
{
    public class CoordenadasRepository : BaseRepository<Coordenada>
    {
        public CoordenadasRepository(ServerContext context) : base(context) {
        }
    }
}