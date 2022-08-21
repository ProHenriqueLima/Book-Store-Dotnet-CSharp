using System.Collections.Generic;

namespace Livraria.WebAPI.Models
{
    public class Editora
    {
        public Editora() { }

        public Editora(int id, string nameEditora, string cidadeEditora)
        {
            Id = id;
            NameEditora = nameEditora;
            CidadeEditora = cidadeEditora;
        }

        public int Id { get; set; }
        public string NameEditora { get; set; }
        public string CidadeEditora { get; set; }
    }
}
