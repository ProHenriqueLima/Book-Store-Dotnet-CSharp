using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Dtos
{
    public class LivroDto
    {
        public int Id{ get; set; }
        public string NomeLivro { get; set; }
        public string LancamentoLivro { get; set; }
        public string AutorLivro { get; set; }
        public int Quantidade { get; set; }
        public int EditoraID { get; set; }
        public Editora Editora { get; set; }
    }
}