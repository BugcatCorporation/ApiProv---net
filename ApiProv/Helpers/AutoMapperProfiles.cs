using ApiProv.DTOs;
using ApiProv.Models;
using AutoMapper;

namespace ApiProv.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Proveedor
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
            CreateMap<ProveedorCreacionDTO, Proveedor>(); 
        }
    }
}
