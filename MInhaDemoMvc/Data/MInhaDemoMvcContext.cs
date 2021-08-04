using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MInhaDemoMvc.Models;

namespace MInhaDemoMvc.Data
{
    public class MInhaDemoMvcContext : DbContext
    {
        public MInhaDemoMvcContext (DbContextOptions<MInhaDemoMvcContext> options)
            : base(options)
        {
        }

        public DbSet<MInhaDemoMvc.Models.Filme> Filme { get; set; }
    }
}
