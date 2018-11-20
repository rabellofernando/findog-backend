using Repository.Context;

namespace Repository
{
    public class UnityOfWork
    {
        ServerContext _context => new ServerContext();

        UsuarioRepository _usuarioRepository;
        CachorrosRepository _cachorroRepository;
        CoordenadasRepository _coordenadasRepository;
        LocalizacaoRepository _localizacaoRepository;
        VacinasRepository _vacinasRepository;
        DispositivosRepository _dispositivosRepository;


        public UsuarioRepository Usuario { get { return _usuarioRepository = (_usuarioRepository ?? new UsuarioRepository(_context)); } }
        public CachorrosRepository Cachorro { get { return _cachorroRepository = (_cachorroRepository ?? new CachorrosRepository(_context)); } }
        public CoordenadasRepository Coordenada { get { return _coordenadasRepository = (_coordenadasRepository ?? new CoordenadasRepository(_context)); } }
        public LocalizacaoRepository Localizacao { get { return _localizacaoRepository = (_localizacaoRepository ?? new LocalizacaoRepository(_context)); } }
        public VacinasRepository Vacinas { get { return _vacinasRepository = (_vacinasRepository ?? new VacinasRepository(_context)); } }
        public DispositivosRepository Dispositivos {  get { return _dispositivosRepository = (_dispositivosRepository ?? new DispositivosRepository(_context)); } }


        public UnityOfWork()
        {

        }
    }
}
