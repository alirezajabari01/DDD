using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Orders.Application.Contract.Orders.Commands;
using Tactical.Orders.Application.Orders.CommandHandlers;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Vendors.Contracts;
using Tactical.Orders.DomainServices;
using Tactical.Orders.Persistence.EF.Contexts;
using Tactical.Orders.Persistence.EF.Orders;
using Tactical.Orders.Persistence.EF.Vendors;
using Tactical.Orders.Query.Contract.MenuItems;
using Tactical.Orders.Query.Contract.Toppings;
using Tactical.Orders.Query.Migrations.EF.Contexts;
using Tactical.Orders.Query.Retrieval.MenuItems;
using Tactical.Orders.Query.Retrieval.Toppings;
using Tactical.Orders.Application.Coupons.EventHandlers;
using Tactical.Framework.Core.Abstractions;
using Tactical.Framework.Persistence.EF;
using Tactical.Orders.Application.Contract.Orders.AppliactionServices;
using Tactical.Orders.ACL.Notification;
using Tactical.Framework.Messaging.EasyNetQ;
using Tactical.Orders.Domain.Contract.IntegrationEvents;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddEasyNetQ(builder.Configuration.GetValue<string>("RabbitMQConnectionString")!);

builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
builder.Services.AddTransient<ICommandHandler<ChangeOrderStateCommand>, ChangeOrderStateCommandHandler>();

builder.Services.AddTransient<IEventHandler<PerformedCouponEvent>, PerformedCouponEventHandler>();


#region Write Repo
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
#endregion

#region Write DomainServices
builder.Services.AddScoped<IVendorDomainService, VendorDomainService>();
builder.Services.AddScoped<ICalculatePriceDomainService, CalculatePriceDomainService>();
builder.Services.AddScoped<IMenuItemDomainService, MenuItemDomainService>();
builder.Services.AddScoped<IToppingDomainService, ToppingDomainService>();
builder.Services.AddScoped<ICouponDomainService, CouponDomainService>();
#endregion

#region Read Repo
builder.Services.AddScoped<IMenuItemReadRepository, MenuItemReadRepository>();
builder.Services.AddScoped<IToppingReadRepository, ToppingReadRepository>();
#endregion

builder.Services.AddScoped<INotificationService, NotificationService>();


builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
           .MinimumLevel
           .Debug()
           .WriteTo.Console().Enrich.FromLogContext()
           .WriteTo.Debug()
           .CreateLogger();

AddDbContext(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();
app.UseSerilogRequestLogging();
app.Run();

void AddDbContext(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddDbContext<FrameworkContext, OrderContext>(options =>
    {
        options.UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString("OrderConnectionString"));


        if (webApplicationBuilder.Environment.IsProduction()) return;

        options.LogTo(message => Console.WriteLine(message));
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
        options.ConfigureWarnings(warningLog =>
        {
            warningLog.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning,
                CoreEventId.RowLimitingOperationWithoutOrderByWarning);
        });
    });

    webApplicationBuilder.Services.AddDbContext<OrderReadContext>(options =>
    {
        options.UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString("OrderConnectionString"),
            sqlOptions => { sqlOptions.MigrationsAssembly(typeof(OrderReadContext).Assembly.FullName); }
        );
    });
}
