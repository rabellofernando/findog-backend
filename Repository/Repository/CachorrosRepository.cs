using Models;
using Repository.Context;

namespace Repository
{
    public class CachorrosRepository : BaseRepository<Cachorro>
    {
        public CachorrosRepository(ServerContext context) : base(context) { }
    }
}