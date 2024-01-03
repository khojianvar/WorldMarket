﻿using WorldMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorldMarket.Infrastructure.Persistence.Configurations
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.HasMany(p => p.SaleItems)
                .WithOne(s => s.Product)
                .HasForeignKey(p => p.ProductId);

            builder.HasMany(p => p.SupplyItems)
                .WithOne(si => si.Product)
                .HasForeignKey(p => p.ProductId);

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(p => p.Description)
                .HasMaxLength(500);
            builder.Property(p => p.Price)
                .HasColumnType("money");
        }
    }
}
