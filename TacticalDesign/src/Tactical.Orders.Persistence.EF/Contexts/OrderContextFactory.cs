using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tactical.Orders.Persistence.EF.Contexts;

public class OrderContextFactory : IDesignTimeDbContextFactory<OrderContext>
{
    //public IConfiguration Configuration = new ConfigurationBuilder()
    //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //    .AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true)
    //    .Build();


    public OrderContext CreateDbContext(string[] args)
    {

        // var deliveryDbContextOptions = Configuration.GetSection("Persistence:DeliveryDbContext").Get<FrameworkDbContextOptions>();


        //if (string.IsNullOrEmpty(deliveryDbContextOptions?.ConnectionString))
        //    throw new Exception("There are not any db context options in configuration.");

        var builder =
            new DbContextOptionsBuilder<OrderContext>()
                .UseNpgsql("Host=localhost:5432;Database=TacticalOrderDB;user id=postgres; Password=123");

        return new OrderContext(builder.Options);

    }
}