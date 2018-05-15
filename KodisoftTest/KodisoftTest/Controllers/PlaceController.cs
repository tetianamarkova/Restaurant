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
    public class PlaceController : Controller
    {

        UnitOfWork unitOfWork;

        public PlaceController(UnitOfWork u)
        {
            this.unitOfWork = u;
        }

        public PartialViewResult PlaceDetails(int placeId = 1)
        {

            var place = unitOfWork.Places.Get(placeId);          
            return PartialView(place);
        }

        public PartialViewResult PlaceTitle(int placeId = 1)
        {          
            var place = unitOfWork.Places.Get(placeId);
            return PartialView(place);
        }

        //we will use such method to display order items while creating a new order or editing the existed one
        public PartialViewResult PlaceOpenedOrders(int selectedValue, int orderId)
        {
            OpenedOrdersForPlaceViewModel model = new OpenedOrdersForPlaceViewModel(); // we need such model to keep the list of items we want to add to the order
            Orders order;
            if (orderId != -1) // if we have the order and want to add one more item, we need to check if we have already such item. In this case, we just increase its amount
            {
                order = unitOfWork.Orders.Get(orderId);
                var previous = order.OrderItem.Select(x => x.ItemId);
                if (previous.Contains(selectedValue))
                {
                    var orderItem = order.OrderItem.ToList().Find(x => x.ItemId == selectedValue);
                    orderItem.ItemAmount++;
                }
                else
                {
                    order.OrderItem.Add(new OrderItem
                    {
                        ItemId = selectedValue,
                        ItemAmount = 1,

                    });
                }

            } else // in case we don't have the order, we will create it and save into Session
            {
                order = (Orders)Session["NewOrder"];
                if(order == null)
                {
                    order = new Orders();
                    Session["NewOrder"] = order;
                }
                var orderItem = order.OrderItem.ToList().Find(x => x.ItemId == selectedValue);
                if (orderItem != null)
                {
                    orderItem.ItemAmount++;
                }
                else
                {
                    order.OrderItem.Add(new OrderItem
                    {
                        ItemId = selectedValue,
                        ItemAmount = 1,

                    });
                }

            }
            model.updatedOrderItems = order.OrderItem.ToList();
            model.menu = unitOfWork.MenuItems.GetAll().ToList();

            return PartialView(model);
        }

        public PartialViewResult CreateOrder(int placeId)
        {

            CreateOrderViewModel model = new CreateOrderViewModel();         
            model.Menu = unitOfWork.MenuItems.GetAll().ToList();
            model.placeId = placeId;
            model.tableId = unitOfWork.Places.Get(placeId).TableId;

            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult GetOrders(int placeId )
        {
            EditOrderViewModel model = new EditOrderViewModel();
            model.Menu = unitOfWork.MenuItems.GetAll().ToList();
            model.placeId = placeId;
            model.tableId = unitOfWork.Places.Get(placeId).TableId;
            model.orders = unitOfWork.Orders.GetAll().Where(x => x.OrderPlaceId == placeId 
                                                    && (x.OrderStatus == 1 || x.OrderStatus == 2 || x.OrderStatus == 3));
            model.statusList = unitOfWork.Status.GetAll().Where(x => x.StatusId == 1 || x.StatusId == 2|| x.StatusId ==3).ToList();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(CreateOrderViewModel model)
        {
            model.tableId = unitOfWork.Places.Get(model.placeId).TableId;
            if (model.updatedOrderItems == null)
            {
                Session["NewOrder"] = null;
                return RedirectToAction("Table", "Home", new { id = model.tableId });
            }
            else
            {
                Orders order = new Orders();
                order.OrderItem = model.updatedOrderItems;
                order.OrderDate = DateTime.Now;
                order.OrderPlaceId = model.placeId;
                order.OrderStatus = unitOfWork.Status.Get(1).StatusId;
                order.OrderTips = 0;

                unitOfWork.Orders.AddOrUpdate(order);

                Session["NewOrder"] = null;
                return RedirectToAction("Table", "Home", new { id = model.tableId });
            }
        }

        [HttpPost]
        public ActionResult EditOrder(EditOrderViewModel model)
        {
            var order = unitOfWork.Orders.Get(model.orderId);
            model.tableId = unitOfWork.Places.Get(model.placeId).TableId;
            order.OrderTips = model.Tips;

            switch (model.submitButton)
            {
                case "Pay":
                    {
                        order.OrderStatus = 4;
                        break;
                    }
                case "Save":
                    {
                        order.OrderStatus = model.SelectedStatus;
                        break;
                    }
                case "Void":
                    {
                        order.OrderStatus = 5;
                        break;
                    }
            }

            unitOfWork.Orders.AddOrUpdate(order);

            return RedirectToAction("Table", "Home",new { id = model.tableId });
        }

    }
}