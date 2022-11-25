using Alexandre_d7_avaliacao.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandre_d7_avaliacao.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsers());
            base.OnModelCreating(modelBuilder);
        }

        private static User[] GetUsers()
        {
            return new User[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    username = "admin@gmail.com",
                    password = "admin123",
                },
            };
        }
    }
}
