using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DatabaseModels;

namespace RepositoryLayer.DataContext
{
    public class InternDataContext : DbContext
    {
        public InternDataContext(DbContextOptions<InternDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetAllInternsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetAllSkillsResult>().HasNoKey().ToView(null);
        }
    }
}
