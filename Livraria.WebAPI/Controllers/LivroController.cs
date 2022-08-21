using AutoMapper;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Dtos;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
 
        
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public LivroController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {   var Livros =_repo.GetAllLivro(includeEditora:true);
            return Ok(_mapper.Map<IEnumerable<LivroDto>>(Livros));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _repo.GetAllLivroByID(id,includeEditora:true);
            if (livro == null) return BadRequest("Livro não encontrado");

            var livroDto = _mapper.Map<LivroDto>(livro);
            return Ok(livroDto);
        }

        [HttpGet("Editora/{EditoraID}")]
        public IActionResult GetByID(int EditoraID)
        {
            var livro = _repo.GetAllLivroByEditoraId(EditoraID,includeEditora:true);
            if (livro == null) return BadRequest("Livro não encontrado");

            return Ok(_mapper.Map<IEnumerable<LivroDto>>(livro));
        }

        [HttpGet("LivroAluguel")]
        public IActionResult GetAll()
        {
            var livro = _repo.GetAllLivroQuatidade(includeEditora:true) ;
            if (livro == null) return BadRequest("Livro não encontrado");

            return Ok(_mapper.Map<IEnumerable<LivroDto>>(livro));
        }
                // Metódos !


        [HttpPost]
        public IActionResult Post(Livro livro)
        {
            _repo.Add(livro);
           if (_repo.SaveChanges())
           {
               var livroDto = _mapper.Map<LivroDto>(livro);
               return Ok(livroDto);
           }
           return BadRequest("Livro não Encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livro)
        {
            var liv = _repo.GetAllLivroByID(id,false);
            if (liv == null) return BadRequest("Livro não encontrado");

            _repo.update(livro);
           if (_repo.SaveChanges())
           {
               return Ok("Livro Atualizado");
           }
           return BadRequest("Livro não Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Livro livro)
        {
            var liv = _repo.GetAllLivroByID(id,false);
            if (liv == null) return BadRequest("Livro não encontrado");

            _repo.update(livro);
           if (_repo.SaveChanges())
           {
               return Ok("Livro Atualizado");
           }
           return BadRequest("Livro não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var liv = _repo.GetAllLivroByID(id,false);
            if (liv == null) return BadRequest("Livro não encontrado");

            _repo.delete(liv);
           if (_repo.SaveChanges())
           {
               return Ok("Livro Deletado");
           }
           return BadRequest("Livro Deletado");
        }
    }
}
