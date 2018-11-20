using Models;
using Repository.Context;

namespace Repository
{
    public class LocalizacaoRepository : BaseRepository<Localizacao>
    {
        public LocalizacaoRepository(ServerContext context) : base(context) { }
    }
}