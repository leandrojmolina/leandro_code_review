using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using App.Domain.Entities;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace App.API.Data.Context
{
    public class SampleAppContext : DbContext
    {
        public SampleAppContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Office> Offices { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:/Users/LeandroMolina/Desktop/Sample-master/server/App.API/App.Data/app.db");
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return this.Database.GetDbConnection().Query<T>(sql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleAppContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }

    public class EmployeeFactory : IDesignTimeDbContextFactory<SampleAppContext>
    {
        SampleAppContext IDesignTimeDbContextFactory<SampleAppContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleAppContext>();
            optionsBuilder.UseSqlite(@"Data Source=./app.db");

            return new SampleAppContext(optionsBuilder.Options);
        }
    }

    
}
