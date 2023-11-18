using ApiProv.DbContexts;
using ApiProv.DTOs;
using ApiProv.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProv.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ProvDbContext context;
        private readonly IMapper mapper;

        public ProveedorRepository(ProvDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProveedorDTO>> GetProveedors()
        {
            var proveedores = await context.Proveedores.ToListAsync();
            return mapper.Map<List<ProveedorDTO>>(proveedores);
        }
        public async Task<ProveedorDTO> GetProveedorById(int id)
        {
            var proveedor = await context.Proveedores.FirstOrDefaultAsync(c => c.Id == id);
            return mapper.Map<ProveedorDTO>(proveedor);
        }
        public async Task<ProveedorDTO> CreateProveedor(ProveedorCreacionDTO proveedorCreacionDTO)
        {
            var proveedor = mapper.Map<Proveedor>(proveedorCreacionDTO);

            context.Add(proveedor);
            await context.SaveChangesAsync();

            var proveedorDTO = mapper.Map<ProveedorDTO>(proveedor);
            return proveedorDTO;
        }

        public async Task<ProveedorDTO> UpdateProveedor(int id, ProveedorCreacionDTO proveedorCreacionDTO)
        {
            var proveedor = mapper.Map<Proveedor>(proveedorCreacionDTO);
            proveedor.Id = id;

            context.Proveedores.Update(proveedor);
            await context.SaveChangesAsync();

            var proveedorDTO = mapper.Map<ProveedorDTO>(proveedor);
            return proveedorDTO;
        }

        public async Task<bool> DeleteProveedor(int id)
        {
            var proveedor = await context.Proveedores.FirstOrDefaultAsync(c => c.Id == id);
            if (proveedor == null)
            {
                return false;
            }
            context.Proveedores.Remove(proveedor);
            await context.SaveChangesAsync();
            return true;
        }
     
    }
}
