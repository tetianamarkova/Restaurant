using Kodisoft.DAL;
using Kodisoft.DAL.Repositories;
using KodisoftTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodisoftTest.Controllers
{
    [Authorize]
    public class OrderHistoryController : Controller
    {

        UnitOfWork unitOfWork;

        public OrderHistoryController(UnitOfWork u)
        {
            this.unitOfWork = u;
        }

        public ActionResult Index()
        {
            OrderHistoryModel model = new OrderHistoryModel();
            model.tables = unitOfWork.Tables.GetAll().ToList();
            model.orders = unitOfWork.Orders.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public PartialViewResult OrderHistoryTable(bool OpenedStatus, bool ClosedStatus, int SelectedTable)
        {
            List<int> statusList = new List<int>();
            IEnumerable<Orders> orders;
            if (OpenedStatus)
            {
                statusList.Add(1);
                statusList.Add(2);
                statusList.Add(3);

            }
            if (ClosedStatus)
            {
                statusList.Add(4);
                statusList.Add(5);
            }
            if (statusList != null || statusList.Count != 0)
            {
                 orders = unitOfWork.Orders.GetAll().Where(x => statusList.Contains(x.OrderStatus) && x.Places.TableId == SelectedTable);
            }else
            {
                orders = unitOfWork.Orders.GetAll().Where(x => x.Places.TableId == SelectedTable);
            }
            return PartialView(orders);
        }

        public PartialViewResult OrderDetails(int? orderId)
        {
            var order = unitOfWork.Orders.Get(orderId.Value);
            return PartialView(order);
        }
    }
}