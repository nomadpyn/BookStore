#region Usings
using BookStore.InventoryManagement.CommandFactory;
using BookStore.InventoryManagement.CommandFactory.Abstract;
using BookStore.InventoryManagement.Context;
using BookStore.InventoryManagement.Context.Abstract;
using BookStore.InventoryManagement.UserInterface.Abstract;
using BookStore.InventoryManagementClient.CatalogService;
using BookStore.InventoryManagementClient.CatalogService.Abstract;
using BookStore.InventoryManagementClient.ConsoleUserInterface;
using Microsoft.Extensions.DependencyInjection;
#endregion

class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var service = serviceProvider.GetService<ICatalogService>();

        service?.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        ConfigureInventoryContext(services);


        services.AddTransient<IUserInterface, ConsoleUserInterface>();
        services.AddTransient<IInventoryCommandFactory, InventoryCommandFactory>();


        services.AddTransient<ICatalogService, CatalogService>();
    }

    private static IServiceCollection ConfigureInventoryContext(IServiceCollection services)
    {
        var context = new InventoryContext();

        services.AddSingleton<IInventoryReadContext, InventoryContext>(p => context);
        services.AddSingleton<IInventoryWriteContext, InventoryContext>(p => context);
        services.AddSingleton<IInventoryContext, InventoryContext>(p => context);

        return services;
    }
}


