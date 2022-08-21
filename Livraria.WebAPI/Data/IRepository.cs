using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity)where T : class;
         void update<T>(T entity)where T : class;
         void delete<T>(T entity)where T : class;
         bool SaveChanges();

         // Editora method

         Editora[] GetAllEditoras();
         Editora GetAllEditoraByID(int EditoraID);
   

         // Livro method

        Livro[] GetAllLivro( bool includeEditora);
        Livro GetAllLivroByID(int EditoraID , bool includeEditora);
        Livro[] GetAllLivroByEditoraId(int LivroID , bool includeEditora);
        Livro[] GetAllLivroQuatidade( bool includeEditora);
       

        Cliente[] GetAllCliente();
        Cliente GetClienteByID(int ClienteID);
        Cliente[] GetAllClienteByName(string EmailCliente);


        Aluguel[] GetAllAluguel(bool includeLivro , bool includeCliente);
        Aluguel[] GetAllAluguelByLivroId(int LivroID);
        Aluguel[] GetAllAluguelByClienteId(int ClienteID);
        Aluguel GetAluguelById(int AluguelID , bool includeLivro , bool includeCliente);
        
    }
}