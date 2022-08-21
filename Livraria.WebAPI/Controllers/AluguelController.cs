using System;
using System.Collections.Generic;
using AutoMapper;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Dtos;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;
        public AluguelController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        
                        // Metódos !
        [HttpGet]
        public IActionResult Get()
        {
            var alugueis = _repo.GetAllAluguel(includeLivro:true, includeCliente:true);
            return Ok(_mapper.Map<IEnumerable<AluguelDto>>(alugueis));
        }
        
        [HttpGet("Livro/{LivroId}")]
        public IActionResult GetByID(int LivroId)
        {
            var aluguel = _repo.GetAllAluguelByLivroId(LivroId);
            if (aluguel == null) return BadRequest("Livro não encontrado");

            return Ok(_mapper.Map<IEnumerable<AluguelDto>>(aluguel));
        }

        [HttpGet("Cliente/{ClienteId}")]
        public IActionResult GetByID2(int ClienteId)
        {
            var aluguel = _repo.GetAllAluguelByClienteId(ClienteId);
            if (aluguel == null) return BadRequest("Cliente não encontrado");

            return Ok(_mapper.Map<IEnumerable<AluguelDto>>(aluguel));
        }


        [HttpPost]
        public IActionResult Post(Aluguel aluguel)
        {   
            var livrinho = _repo.GetAllLivroByID(aluguel.LivroId,includeEditora:false);
            if (livrinho.Quantidade <= 0){
                return BadRequest("Este Livro Não Está Disponivel Para Alugar");
            }else{
           
            _repo.Add(aluguel);

           if (_repo.SaveChanges())
           {
               var aluguelDto = _mapper.Map<AluguelDto>(aluguel);
               return Ok(aluguelDto);
           }
           return BadRequest("Aluguel não Concluido");
          }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluguel aluguel)
        {
            var alu = _repo.GetAluguelById(id, includeLivro:true, includeCliente:true);
            if (alu == null) return BadRequest("Aluguel não encontrado");

            _repo.update(aluguel);
           if (_repo.SaveChanges())
           {
               return Ok("Aluguel Atualizado");
           }
           return BadRequest("Aluguel não Atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluguel aluguel)
        {
            var alu = _repo.GetAluguelById(id, includeLivro:true, includeCliente:true);
            if (alu == null) return BadRequest("Aluguel não encontrado");

            _repo.update(aluguel);
           if (_repo.SaveChanges())
           {
               return Ok("Aluguel Atualizado");
           }
           return BadRequest("Aluguel não Atualizado");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAluguelById(id,false,false);
            if (alu == null) return BadRequest("Aluguel não encontrado");

            _repo.delete(alu);
           if (_repo.SaveChanges())
           {
               return Ok("Aluguel Deletado");
           }
           return BadRequest("Aluguel Deletado");
        }
    }
}