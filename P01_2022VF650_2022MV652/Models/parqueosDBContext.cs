using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace P01_2022VF650_2022MV652.Models
{
    public class parqueosDBContext : DbContext
    {
            public parqueosDBContext(DbContextOptions<parqueosDBContext> options) : base(options)
            {
            }
            public DbSet<usuarios> usuarios { get; set; }

            public DbSet<sucursales> sucursales { get; set; }

            public DbSet<espacios> espacios_parqueo{ get; set; }

           public DbSet<reservas> reservas { get; set; }



    }
}
