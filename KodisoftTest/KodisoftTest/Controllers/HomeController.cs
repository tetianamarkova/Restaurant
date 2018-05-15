using Kodisoft.DAL.Repositories;
using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodisoftTest.Models;

namespace KodisoftTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;

        public HomeController(UnitOfWork u)
        {
            unitOfWork = u;
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = unitOfWork.Tables.GetAll();           
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult TableDetails(int placeId = 1)
        {
            var place = unitOfWork.Places.Get(placeId);
            return PartialView(place);
        }

        public ActionResult Table(int id = 1)
        {
            var model = unitOfWork.Tables.Get(id);
            return View(model);
        }

        public PartialViewResult TablesCoordinates()
        {
            TableCoordinatesViewModel model = new TableCoordinatesViewModel();
            model.Tables = unitOfWork.Tables.GetAll().ToList();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditCoordinates(TableCoordinatesViewModel model)
        {
            if(model.positionX > 0 && model.positionX < 860 && model.positionY > 0 && model.positionY < 490)
            {
                Tables updateTable = unitOfWork.Tables.Get(model.SelectedTable);
                updateTable.PositionX = model.positionX;
                updateTable.PositionY = model.positionY;

                unitOfWork.Tables.AddOrUpdate(updateTable);
            }
            return RedirectToAction("Index","Home");
        }

        public int getPositionX (int id = 1)
        {
            return unitOfWork.Tables.Get(id).PositionX;
        }

        public int getPositionY(int id = 1)
        {
            return unitOfWork.Tables.Get(id).PositionY;
        }

    }
}