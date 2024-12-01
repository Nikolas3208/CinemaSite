using CinemaSite.Domain.Configurations;
using CinemaSite.Domain.Enums;
using CinemaSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Domain
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
