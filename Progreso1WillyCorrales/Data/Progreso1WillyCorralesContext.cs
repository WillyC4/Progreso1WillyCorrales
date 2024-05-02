using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progreso1WillyCorrales.Models;

namespace Progreso1WillyCorrales.Data
{
    public class Progreso1WillyCorralesContext : DbContext
    {
        public Progreso1WillyCorralesContext (DbContextOptions<Progreso1WillyCorralesContext> options)
            : base(options)
        {
        }

        public DbSet<Progreso1WillyCorrales.Models.WCorrales> WCorrales { get; set; } = default!;
    }
}
