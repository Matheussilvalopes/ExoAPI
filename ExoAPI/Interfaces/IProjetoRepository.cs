using ExoAPI.Models;

namespace ExoAPI.Interfaces
{
    public interface IProjetoRepository
    {
        List<Projeto> Listar();
        void Cadastrar(Projeto projeto);
        void Atualizar(int id, Projeto projeto);
        void Deletar(int id);
        Projeto BuscaPorId(int id);
    }
}
