using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Dtos;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        
        private readonly IRepository _repo;
         private readonly IMapper _mapper;

        public EditoraController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


                // Metódos !

        [HttpGet]
        public IActionResult Get()
        {
            var editora =_repo.GetAllEditoras();
            return Ok(_mapper.Map<IEnumerable<EditoraDto>>(editora));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var editora = _repo.GetAllEditoraByID(id);
            if (editora == null) return BadRequest("Editora não encontrado");
            var editoraDto = _mapper.Map<EditoraDto>(editora);
            return Ok(editoraDto);
        }
        
        [HttpPost]
        public IActionResult Post(Editora editora)
        {
           _repo.Add(editora);
           if (_repo.SaveChanges())
           {
            var editoraDto = _mapper.Map<EditoraDto>(editora);
            return Ok(editoraDto);
           }
           return BadRequest("Editora não encontrada");
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Editora editora)
        {
            var edi = _repo.GetAllEditoraByID(id);
            if (edi == null) return BadRequest("Editora não encontrado");

            _repo.update(editora);
           if (_repo.SaveChanges())
           {
               return Ok("Editora Atualizada");
           }
           return BadRequest("Editora não Atualizada");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Editora editora)
        {   
           var edi = _repo.GetAllEditoraByID(id);
            if (edi == null) return BadRequest("Editora não encontrado");

            _repo.update(editora);
           if (_repo.SaveChanges())
           {
               var editoraDto = _mapper.Map<EditoraDto>(editora);
            return Ok(editoraDto);
           }
           return BadRequest("Editora não Atualizada");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   
            var edi = _repo.GetAllEditoraByID(id);
            if (edi == null) return BadRequest("Editora não encontrado");

            _repo.delete(edi);
           if (_repo.SaveChanges())
           {
               return Ok("Editora Deletada");
           }
           return BadRequest("Editora não Deletada");
        }



    }
}