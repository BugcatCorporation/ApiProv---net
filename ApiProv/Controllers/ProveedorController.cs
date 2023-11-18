using ApiProv.DTOs;
using ApiProv.Models;
using ApiProv.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController: ControllerBase
    {
        private readonly IProveedorRepository repository;
        private readonly IMapper mapper;

        public ProveedorController(IProveedorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProveedorDTO>>> GetProveedores()
        {
            return Ok(await repository.GetProveedors());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(int id)
        {
            var proveedor = await repository.GetProveedorById(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> CreateProveedor([FromBody]ProveedorCreacionDTO proveedorCreacionDTO)
        {
            var proveedorDTO = await repository.CreateProveedor(proveedorCreacionDTO);
            if (proveedorDTO == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetProveedor), new { id = proveedorDTO.Id }, proveedorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProveedorDTO>> UpdateProveedor(int id,ProveedorCreacionDTO proveedorCreacionDTO)
        {
            var proveedorDTO = await repository.UpdateProveedor(id, proveedorCreacionDTO);
            if (proveedorDTO == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Proveedor>> DeleteProveedor(int id)
        {
            var proveedor = await repository.GetProveedorById(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            await repository.DeleteProveedor(proveedor.Id);
            return NoContent();
        }
    }
}
