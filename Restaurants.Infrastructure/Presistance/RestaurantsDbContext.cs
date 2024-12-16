﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Presistance;

public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);

    }

}