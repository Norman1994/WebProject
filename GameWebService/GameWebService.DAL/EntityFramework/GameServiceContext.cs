using GameWebService.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWebService.DAL.EntityFramework
{
    public class GameServiceContext : DbContext
    {
        private IConfiguration _config;

        public GameServiceContext(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Result> Results { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
