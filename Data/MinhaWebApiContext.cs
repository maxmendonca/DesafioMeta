using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinhaWebApi.Models
{
    public class MinhaWebApiContext : DbContext
    {
        public MinhaWebApiContext (DbContextOptions<MinhaWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<MinhaWebApi.Models.Contato> Contato { get; set; }

        public DbSet<TipoContato> TipoContato { get; set; }
    }
}
