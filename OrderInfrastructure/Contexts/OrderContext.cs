using Microsoft.EntityFrameworkCore;
using OrderInfrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure.Contexts;

public class OrderContext(DbContextOptions<OrderContext> options) : DbContext(options)
{
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<CartItemOrderEntity> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderEntity>()
            .HasMany(s => s.Items)
            .WithOne(ci => ci.Order);
    }
}
