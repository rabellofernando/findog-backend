using Models;
using Repository.Context;

namespace Repository
{
    public class VacinasRepository : BaseRepository<Vacina>
    {
        public VacinasRepository(ServerContext context) : base(context) { }
    }
}