using Microsoft.EntityFrameworkCore;
using Tarea6Lab.Models;

namespace Tarea6Lab.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosDetalle>? ProductosDetalles { get; set; }
  
        public Contexto(DbContextOptions<Contexto> options) : base(options){}
    }
}