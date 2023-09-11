using Microsoft.EntityFrameworkCore;
using Registro_Prioridad1.Models;

namespace Registro_Prioridad1.DAL
{
    public class PrioridadContext : DbContext
    {
        public PrioridadContext(DbContextOptions<PrioridadContext> Options)
            : base(Options) { }
        public DbSet<Sistemas> Sistemas { get; set; }
    }
}