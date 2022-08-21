using System.Collections.Generic;
using System.Linq;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repo;


        public ClienteController( IRepository repo)
        {
            _repo = repo;
        }


                 // Metódos !

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllCliente());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _repo.GetClienteByID(id);
            if (cliente == null) return BadRequest("Cliente não encontrado");
            return Ok(cliente);
        }

        [HttpGet("email/{EmailCliente}")]
        public IActionResult GetByEmail(string EmailCliente)
        {
            var cliente = _repo.GetAllClienteByName(EmailCliente);
            if (cliente == null) return BadRequest("Email Já Cadastrado");
            return Ok(cliente);
        }
        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            _repo.Add(cliente);
           if (_repo.SaveChanges())
           {
               return Ok(cliente);
           }
           return BadRequest("Cliente não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente cliente)
        {
            var clie = _repo.GetClienteByID(id);
            if (clie == null) return BadRequest("Cliente não encontrado");

            _repo.update(cliente);
           if (_repo.SaveChanges())
           {
               return Ok("liente Atualizado");
           }
           return BadRequest("Cliente não Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Cliente cliente)
        {
            var cli = _repo.GetClienteByID(id);
            if (cli == null) return BadRequest("Cliente não encontrado");

            _repo.update(cliente);
           if (_repo.SaveChanges())
           {
               return Ok(cliente);
           }
           return BadRequest("Cliente não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cli = _repo.GetClienteByID(id);
            if (cli == null) return BadRequest("Cliente não encontrado");

            _repo.delete(cli);
           if (_repo.SaveChanges())
           {
               return Ok("Cliente Deletado");
           }
           return BadRequest("Cliente não Deletado");
        }



    }
}