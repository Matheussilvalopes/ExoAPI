using ExoAPI.Contexts;
using ExoAPI.Interfaces;
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ExoContext _exoContext;
        public UsuarioRepository(ExoContext context) 
        {
            _exoContext = context;
        }
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado=_exoContext.Usuarios.Find(id);
            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Tipo = usuario.Tipo;
            }
            _exoContext.Usuarios.Update(usuarioBuscado);
            _exoContext.SaveChanges();

        }

        public Usuario BuscaPorId(int id)
        {
            return _exoContext.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _exoContext.Usuarios.Add(usuario);
            _exoContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _exoContext.Usuarios.Find(id);
           _exoContext.Usuarios.Remove(usuarioBuscado);
            _exoContext.SaveChanges();
        }

        public List<Usuario> Listar()
        {
           return _exoContext.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
