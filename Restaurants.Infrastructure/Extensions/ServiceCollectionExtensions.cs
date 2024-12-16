﻿using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
    }
}