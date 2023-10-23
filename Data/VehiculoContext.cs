using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using herramientas_parcial1_OliveraJorgeDaniel.Models;

namespace Race_Track.Data
{
    public class VehiculoContext : DbContext
    {
        public VehiculoContext(DbContextOptions<VehiculoContext> options)
            : base(options)
        {
        }

        public DbSet<herramientas_parcial1_OliveraJorgeDaniel.Models.Vehiculo> Vehiculo { get; set; } = default!;

        public DbSet<herramientas_parcial1_OliveraJorgeDaniel.Models.Piloto> Piloto { get; set; } = default!;
    }
}
