using System.Web.Mvc;
using System.Web.Routing;
using SimpleCQRS.Aggregate;
using SimpleCQRS.Bus;
using SimpleCQRS.CommandHandlers;
using SimpleCQRS.Commands;
using SimpleCQRS.Databases.Write;
using SimpleCQRS.EventHandlers;
using SimpleCQRS.Events;
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

            routes.MapRoute(name: "Default",
                            url: "{controller}/{action}/{id}",
                            defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            RegisterServiceBus();
        }

        private static void RegisterServiceBus()
        {
            var bus = new FakeBus();

            RegisterCommandHandlers(bus);

            RegisterDetailsViewEventHandlers(bus);

            RegisterListViewEventHandlers(bus);

            ServiceLocator.Bus = bus;
        }

        private static void RegisterCommandHandlers(FakeBus bus)
        {
            var storage = new EventStore(bus);
            var repository = new Repository<InventoryItem>(storage);
            var commands = new InventoryCommandHandlers(repository);

            bus.RegisterHandler<CheckInItemsToInventoryCommand>(commands.Handle);
            bus.RegisterHandler<CreateInventoryItemCommand>(commands.Handle);
            bus.RegisterHandler<DeactivateInventoryItemCommand>(commands.Handle);
            bus.RegisterHandler<RemoveItemsFromInventoryCommand>(commands.Handle);
            bus.RegisterHandler<RenameInventoryItemCommand>(commands.Handle);
        }

        private static void RegisterDetailsViewEventHandlers(FakeBus bus)
        {
            var detail = new InventoryItemDetailView();

            bus.RegisterHandler<InventoryItemCreated>(detail.Handle);
            bus.RegisterHandler<InventoryItemDeactivated>(detail.Handle);
            bus.RegisterHandler<InventoryItemRenamed>(detail.Handle);
            bus.RegisterHandler<ItemsCheckedInToInventory>(detail.Handle);
            bus.RegisterHandler<ItemsRemovedFromInventory>(detail.Handle);
        }

        private static void RegisterListViewEventHandlers(FakeBus bus)
        {
            var list = new InventoryListView();

            bus.RegisterHandler<InventoryItemCreated>(list.Handle);
            bus.RegisterHandler<InventoryItemRenamed>(list.Handle);
            bus.RegisterHandler<InventoryItemDeactivated>(list.Handle);
        }
    }
}
