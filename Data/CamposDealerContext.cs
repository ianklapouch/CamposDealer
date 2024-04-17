using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CamposDealer.Models;

namespace CamposDealer.Data
{
    public class CamposDealerContext : DbContext
    {
        public CamposDealerContext (DbContextOptions<CamposDealerContext> options)
            : base(options)
        {
        }

        public DbSet<CamposDealer.Models.Cliente> Cliente { get; set; } = default!;
    }
}
