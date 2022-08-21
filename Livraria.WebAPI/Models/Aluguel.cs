using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebAPI.Models
{
    public class Aluguel
    {

        public Aluguel(int id, int clienteId, int livroId, string data_Aluguel, string previsao, string entrega, string status
        )
        {
            this.Id = id;
            this.ClienteId = clienteId;
            this.LivroId = livroId;
            this.Data_Aluguel= data_Aluguel;
            this.Previsao = previsao;
            this.Entrega = entrega;
            this.Status = status;

        }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public string Data_Aluguel { get; set;}
        public string Previsao { get; set;}
        public string Entrega { get; set;}
        public string Status { get; set;}

    }
}
