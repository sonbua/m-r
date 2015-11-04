using System;
using System.Web.Mvc;
using SimpleCQRS.Bus;
using SimpleCQRS.Commands;
using SimpleCQRS.Facade;

namespace CQRSGui.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly FakeBus _bus;
        private readonly ReadModelFacade _readModel;

        public HomeController()
        {
            _bus = ServiceLocator.Bus;
            _readModel = new ReadModelFacade();
        }

        public ActionResult Index()
        {
            ViewData.Model = _readModel.GetInventoryItems();

            return View();
        }

        public ActionResult Details(Guid id)
        {
            ViewData.Model = _readModel.GetInventoryItemDetails(id);

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            _bus.Send(new CreateInventoryItemCommand(Guid.NewGuid(), name));

            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            ViewData.Model = _readModel.GetInventoryItemDetails(id);

            return View();
        }

        [HttpPost]
        public ActionResult ChangeName(Guid id, string name, int version)
        {
            _bus.Send(new RenameInventoryItemCommand(id, name, version));

            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(Guid id, int version)
        {
            _bus.Send(new DeactivateInventoryItemCommand(id, version));

            return RedirectToAction("Index");
        }

        public ActionResult CheckIn(Guid id)
        {
            ViewData.Model = _readModel.GetInventoryItemDetails(id);

            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(Guid id, int number, int version)
        {
            _bus.Send(new CheckInItemsToInventoryCommand(id, number, version));

            return RedirectToAction("Index");
        }

        public ActionResult Remove(Guid id)
        {
            ViewData.Model = _readModel.GetInventoryItemDetails(id);

            return View();
        }

        [HttpPost]
        public ActionResult Remove(Guid id, int number, int version)
        {
            _bus.Send(new RemoveItemsFromInventoryCommand(id, number, version));

            return RedirectToAction("Index");
        }
    }
}
