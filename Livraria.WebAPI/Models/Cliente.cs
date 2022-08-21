namespace Livraria.WebAPI.Models
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(int id, string nomeCliente, string cidadeCliente, string enderecoCliente, string emailCliente)
        {
            Id = id;
            NomeCliente = nomeCliente;
            CidadeCliente = cidadeCliente;
            EnderecoCliente = enderecoCliente;
            EmailCliente = emailCliente;
        }

        public int Id { get; set; }

        public string NomeCliente { get; set; }

        public string CidadeCliente { get; set; }

        public string EnderecoCliente { get; set; }

        public string EmailCliente { get; set; }

    }
}