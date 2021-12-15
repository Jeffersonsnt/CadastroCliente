using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.DAL;
using CadastroCliente.Models;
using CadastroCliente.Repositories;

namespace CadastroCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IRepository<Cliente> repository;

        public ClientesController(ClienteContext context)
        {
            repository = new Repository<Cliente>(context);
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await Task.FromResult(repository.GetAll().ToList());
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await Task.FromResult(repository.GetbyId(id));

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return await Task.FromResult(BadRequest());
            }

            repository.Update(cliente);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await Task.FromResult(ClienteExists(id)))
                {
                    return await Task.FromResult(NotFound());
                }
                else
                {
                    throw;
                }
            }

            return await Task.FromResult(NoContent());
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            repository.Insert(cliente);
            repository.Save();

            return await Task.FromResult(CreatedAtAction("GetCliente", new
            {
                id = cliente.Id
            }, cliente));
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await Task.FromResult(repository.GetbyId(id));

            if (cliente == null)
            {
                return await Task.FromResult(NotFound());
            }

            repository.Delete(cliente);
            repository.Save();

            return await Task.FromResult(NoContent());
        }

        private bool ClienteExists(int id)
        {
            return repository.GetAll().Any(x => x.Id == id);
        }
    }
}
