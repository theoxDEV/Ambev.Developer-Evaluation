using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    /// <summary>
    /// Represents the Users table in the database.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Represents the Sales table in the database.
    /// </summary>
    public DbSet<Sale> Sales { get; set; }

    /// <summary>
    /// Represents the SaleItems table in the database.
    /// </summary>
    public DbSet<SaleItem> SaleItems { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
        modelBuilder.SeedBusinessRuleExamples();
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
            connectionString,
            b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        );


        return new DefaultContext(builder.Options);
    }
}