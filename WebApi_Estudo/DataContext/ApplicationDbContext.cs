using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.Models;

namespace WebApi_Estudo.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
                
        }
        
        public DbSet<Lead> Lead { get; set; }

        public DbSet<Oferta> Oferta { get; set; }

        public DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }

        public DbSet<Inscricao> Inscricao { get; set; }
    }
}
