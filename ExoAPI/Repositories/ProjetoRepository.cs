using ExoAPI.Contexts;
using ExoAPI.Interfaces;
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ExoContext _exoContext;
        public ProjetoRepository(ExoContext context)
        {
            _exoContext = context;
        }

        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _exoContext.Projetos.Find(id);
            if (projetoBuscado != null)
            {
                projetoBuscado.Titulo = projeto.Titulo;
                projetoBuscado.QuantidadeDesenvolvedores = projeto.QuantidadeDesenvolvedores;
                projetoBuscado.Prioridade = projeto.Prioridade;
            }
            _exoContext.Projetos.Update(projetoBuscado);
            _exoContext.SaveChanges();
        }

        public Projeto BuscaPorId(int id)
        {
            return _exoContext.Projetos.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _exoContext.Projetos.Add(projeto);
            _exoContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto projeto = _exoContext.Projetos.Find(id);

            if(projeto != null)
            {
                _exoContext.Projetos.Remove(projeto);
            }

            _exoContext.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return _exoContext.Projetos.ToList();
        }
    }
}
