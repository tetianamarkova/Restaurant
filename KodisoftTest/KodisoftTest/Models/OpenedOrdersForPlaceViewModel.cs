using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodisoftTest.Models
{
    public class OpenedOrdersForPlaceViewModel
    {
        public List<OrderItem> updatedOrderItems { get; set; }
        public List<MenuItems> menu { get; set; }
    }
}