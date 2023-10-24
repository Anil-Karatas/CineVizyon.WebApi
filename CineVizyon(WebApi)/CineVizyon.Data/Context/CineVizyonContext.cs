using CineVizyon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVizyon.Data.Context
{
    public class CineVizyonContext :DbContext
    {
        public CineVizyonContext(DbContextOptions<CineVizyonContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieEntity>().HasQueryFilter(x => x.IsDeleted == false);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MovieEntity> Movies => Set<MovieEntity>();

    }
}
