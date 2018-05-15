using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KodisoftTest.Models
{
    public class CreateOrderViewModel
    {
        public List<MenuItems> Menu { get; set; }
        public int[] SelectedMenuItem { get; set; }
        public int placeId { get; set; }
        public List<OrderItem> updatedOrderItems { get; set; }
        public int tableId { get; set; }

    }

}