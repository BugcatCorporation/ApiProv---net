using ApiProv.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProv.DbContexts
{
    public class ProvDbContext : DbContext
    {
        public ProvDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Proveedor> Proveedores { get; set; }
    }
}
