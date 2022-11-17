using Microsoft.EntityFrameworkCore;
using SGHotelAPI.Model;

namespace SGHotelAPI.Model
{
    public class SGHotelContext : DbContext
    {
        public SGHotelContext(DbContextOptions <SGHotelContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Andar> Andares { get; set; }
        public DbSet<Reserva> reservas  { get; set; }

    }
}
