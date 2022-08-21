using System.Linq;
using Livraria.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.WebAPI.Data
{
    public class Repository : IRepository
    {   
        private readonly LivrariaContext context;
        public Repository(LivrariaContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }
        public void update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }
        public void delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() > 0);
        }

        public Editora[] GetAllEditoras()
        {
            IQueryable<Editora> query = this.context.Editoras;

            query = query.AsNoTracking().OrderBy(livro => livro.Id);

            return query.ToArray();
        }

        public Editora GetAllEditoraByID(int EditoraID)
        {
            IQueryable<Editora> query = this.context.Editoras;
            query = query.AsNoTracking()
            .OrderBy(a => a.Id)
            .Where(editora => editora.Id == EditoraID);
            return query.FirstOrDefault();
        }

        public Livro[] GetAllLivro( bool includeEditora)
        {
           IQueryable<Livro> query = this.context.Livros;

           if(includeEditora){
               query = query.Include(e => e.Editora);
           }

            query = query.AsNoTracking().OrderBy(livro => livro.Id);

            return query.ToArray();
        }

        public Livro GetAllLivroByID(int LivroID, bool includeEditora)
        {
            IQueryable<Livro> query = this.context.Livros;
            if(includeEditora){
               query = query.Include(e => e.Editora);
           }
            query = query.AsNoTracking()
            .OrderBy(livro => livro.Id)
            .Where(livro => livro.Id == LivroID);
            return query.FirstOrDefault();
        }

        public Cliente[] GetAllCliente()
        {
            IQueryable<Cliente> query = this.context.Clientes;

            query = query.AsNoTracking().OrderBy(cliente => cliente.Id);

            return query.ToArray();
        }

        public Cliente GetClienteByID(int ClienteID)
        {
            IQueryable<Cliente> query = this.context.Clientes;
            query = query.AsNoTracking()
            .OrderBy(cliente => cliente.Id)
            .Where(cliente => cliente.Id == ClienteID);
            return query.FirstOrDefault();
        }


        public Aluguel GetAluguelById(int AluguelID, bool includeLivro, bool includeCliente)
        {
            IQueryable<Aluguel> query = this.context.Alugueis;
            if(includeLivro){
               query = query.Include(l => l.Livro);
           }
           if(includeCliente){
               query = query.Include(c => c.Cliente);
           }
            query = query.AsNoTracking()
            .OrderBy(Aluguel => Aluguel.Id)
            .Where(Aluguel => Aluguel.Id == AluguelID);
            return query.FirstOrDefault();
        }
        public Aluguel[] GetAllAluguel(bool includeLivro , bool includeCliente)
        {
            IQueryable<Aluguel> query = this.context.Alugueis;

           if(includeLivro){
               query = query.Include(l => l.Livro);
           }
           if(includeCliente){
               query = query.Include(c => c.Cliente);
           }

            query = query.AsNoTracking().OrderBy(aluguel => aluguel.Id);

            return query.ToArray();
        }

        public Livro[] GetAllLivroByEditoraId(int EditoraID, bool includeEditora)
        {
            IQueryable<Livro> query = this.context.Livros;
            if(includeEditora){
               query = query.Include(e => e.Editora);
           }
            query = query.AsNoTracking()
            .OrderBy(livro => livro.EditoraID)
            .Where(livro => livro.EditoraID == EditoraID);
            return query.ToArray();
            }

        public Aluguel[] GetAllAluguelByLivroId(int LivroID)
        {
            IQueryable<Aluguel> query = this.context.Alugueis;
            query = query.AsNoTracking()
            .OrderBy(aluguel => aluguel.LivroId)
            .Where(aluguel => aluguel.LivroId == LivroID);
            return query.ToArray();
        }

        public Aluguel[] GetAllAluguelByClienteId(int ClienteID)
        {
            IQueryable<Aluguel> query = this.context.Alugueis;
            query = query.AsNoTracking()
            .OrderBy(aluguel => aluguel.ClienteId)
            .Where(aluguel => aluguel.ClienteId == ClienteID);
            return query.ToArray();
        }

        public Livro[] GetAllLivroQuatidade(bool includeEditora)
        {
            IQueryable<Livro> query = this.context.Livros;

           if(includeEditora){
               query = query.Include(e => e.Editora);
           }

            query = query.AsNoTracking().OrderBy(livro => livro.Id)
            .Where(livro => livro.Quantidade >= 0);

            return query.ToArray();
        }

        public Cliente[] GetAllClienteByName(string EmailCliente)
        {
            IQueryable<Cliente> query = this.context.Clientes;
            query = query.AsNoTracking()
            .OrderBy(cliente => cliente.Id)
            .Where(cliente => cliente.EmailCliente == EmailCliente);
            return query.ToArray();
        }
    }
    }
