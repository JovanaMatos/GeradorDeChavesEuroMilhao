using Microsoft.EntityFrameworkCore;
using EuroMilhao2.Models;

namespace EuroMilhao2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<KeysGeradas> KeysGeradas { get; set; }//informando qual classe sera mapeada
    }
}

