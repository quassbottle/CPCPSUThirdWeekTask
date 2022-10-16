using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Week3.Domain.Entities;

namespace Week3.Migration;

public class ProductContext : DbContext
{
    public ProductContext()
    {
    }
    
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "products.db" };
        var connectionString = connectionStringBuilder.ToString();
        var connection = new SqliteConnection(connectionString);

        optionsBuilder.UseSqlite(connection);
    }

    public DbSet<Product> Products { get; set; }
}