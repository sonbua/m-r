using System.Web.Mvc;
using System.Web.Routing;
using SimpleCQRS.Aggregate;
using SimpleCQRS.Bus;
using SimpleCQRS.CommandHandlers;
using SimpleCQRS.Commands;
using SimpleCQRS.Events;
using SimpleCQRS.EventStore;
using SimpleCQRS.Handles;
using SimpleCQRS.Repository;

namespace CQRSGui
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Default", // Route name
                            url: "{controller}/{action}/{id}", // URL with parameters
                            defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            var bus = new FakeBus();

            var storage = new EventStore(bus);
            var repository = new Repository<InventoryItem>(storage);
            var commands = new InventoryCommandHandlers(repository);

            bus.RegisterHandler<CheckInItemsToInventoryCommand>(commands.Handle);
            bus.RegisterHandler<CreateInventoryItemCommand>(commands.Handle);
            bus.RegisterHandler<DeactivateInventoryItemCommand>(commands.Handle);
            bus.RegisterHandler<RemoveItemsFromInventoryCommand>(commands.Handle);
            bus.RegisterHandler<RenameInventoryItemCommand>(commands.Handle);

            var detail = new InventoryItemDetailView();

            bus.RegisterHandler<InventoryItemCreated>(detail.Handle);
            bus.RegisterHandler<InventoryItemDeactivated>(detail.Handle);
            bus.RegisterHandler<InventoryItemRenamed>(detail.Handle);
            bus.RegisterHandler<ItemsCheckedInToInventory>(detail.Handle);
            bus.RegisterHandler<ItemsRemovedFromInventory>(detail.Handle);

            var list = new InventoryListView();

            bus.RegisterHandler<InventoryItemCreated>(list.Handle);
            bus.RegisterHandler<InventoryItemRenamed>(list.Handle);
            bus.RegisterHandler<InventoryItemDeactivated>(list.Handle);

            ServiceLocator.Bus = bus;
        }
    }
}
