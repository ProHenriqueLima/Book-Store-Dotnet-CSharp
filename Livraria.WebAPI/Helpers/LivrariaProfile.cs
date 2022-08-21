using AutoMapper;
using Livraria.WebAPI.Dtos;
using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Helpers
{
    public class LivrariaProfile : Profile
    {
        public LivrariaProfile()
        {
            CreateMap<Livro, LivroDto>();
            CreateMap<Editora, EditoraDto>();
            CreateMap<Aluguel, AluguelDto>();
        }
    }
}