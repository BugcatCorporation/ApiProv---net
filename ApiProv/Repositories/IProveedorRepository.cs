using ApiProv.DTOs;
using ApiProv.Models;

namespace ApiProv.Repositories
{
    public interface IProveedorRepository
    {
        Task<List<ProveedorDTO>> GetProveedors();
        Task<ProveedorDTO> GetProveedorById(int id);
        Task<ProveedorDTO> CreateProveedor(ProveedorCreacionDTO proveedorCreacionDTO);
        Task<ProveedorDTO> UpdateProveedor(int id, ProveedorCreacionDTO proveedorCreacionDTO);
        Task<bool> DeleteProveedor(int id);
    }
}
