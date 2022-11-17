using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHotelAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHotelAPI.Controllers
{
    [Route("apiHotel/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase 
    {
        private readonly SGHotelContext _context;
        public ClientesController(SGHotelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            return cliente;

        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var existe = _context.Clientes.Where(x => x.Cpf == cliente.Cpf);

            if (existe.Any())
                return Ok("cliente já existe!");

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new {id = cliente.IdCliente}, cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var clienteDelete = await _context.Clientes.FindAsync(id);

            if (clienteDelete == null)
                return NotFound();
                
             _context.Clientes.Remove(clienteDelete);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, Cliente cliente)
        {
            if(id != cliente.IdCliente)
                return BadRequest();
                
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return NoContent();
        }

    }
}
