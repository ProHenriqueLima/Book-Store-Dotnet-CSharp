using Livraria.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livraria.WebAPI.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options){}
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            
            
            


        }

    }
}