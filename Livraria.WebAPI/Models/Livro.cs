using System.Collections.Generic;

namespace Livraria.WebAPI.Models
{
    public class Livro
    {
        public Livro(){}

        public Livro(int id, string nomeLivro, string lancamentoLivro, string autorLivro, int quantidade, int editoraId)
        {
            Id = id;
            NomeLivro = nomeLivro;
            LancamentoLivro = lancamentoLivro;
            AutorLivro = autorLivro;
            Quantidade = quantidade;
            EditoraID = editoraId;
        }

        public int Id{ get; set; }
        public string NomeLivro { get; set; }
        public string LancamentoLivro { get; set; }
        public string AutorLivro { get; set; }
        public int Quantidade { get; set; }
        public int EditoraID { get; set; }
        public Editora Editora { get; set; }
        
    }
}