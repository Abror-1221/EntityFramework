using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Persons> Persons { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Profilings> Profilings { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<Universities> Universities { get; set; }
        public DbSet<RoleAccounts> RoleAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleAccounts>()
                .HasKey(ar => new { ar.AccountsNIK, ar.RolesId });
            modelBuilder.Entity<RoleAccounts>()
                .HasOne(ar => ar.Accounts)
                .WithMany(a => a.RoleAccounts)
                .HasForeignKey(ar => ar.AccountsNIK);
            modelBuilder.Entity<RoleAccounts>()
                .HasOne(ar => ar.Roles)
                .WithMany(r => r.RoleAccounts)
                .HasForeignKey(ar => ar.RolesId);
        }
    }
}
