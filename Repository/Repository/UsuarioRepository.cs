using Models;
using Repository.Context;

namespace Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(ServerContext context) : base(context) { }
    }
}