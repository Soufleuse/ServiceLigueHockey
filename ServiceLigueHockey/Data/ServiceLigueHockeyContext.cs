using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Models;

namespace ServiceLigueHockey.Data
{
    public class ServiceLigueHockeyContext : DbContext
    {
        public ServiceLigueHockeyContext() { }

        public ServiceLigueHockeyContext (DbContextOptions<ServiceLigueHockeyContext> options)
            : base(options)
        {
        }

        public DbSet<EquipBd> Equipe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VMWIN10PRO\\SQLEXPRESS;Database=LigueHockey;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
