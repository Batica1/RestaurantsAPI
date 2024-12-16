using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Presistance;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RestaurantsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Restaurants.Infrastructure")));


// Register the Seeder service
builder.Services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

var app = builder.Build();

// Run the Seeder to populate the database
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
