using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodisoftTest.Models
{


    public class EditOrderViewModel
    {

        public List<MenuItems> Menu { get; set; }
        public int[] SelectedMenuItem { get; set; }
        public List<OrderItem> updatedOrderItems { get; set; }
        public int placeId { get; set; }
        public int orderId { get; set; }
        public int SelectedStatus{ get; set; }
        public double Tips { get; set; }
        public IEnumerable<Orders> orders { get; set; }
        public List<StatusList> statusList { get; set; } 
        public string submitButton { get; set; }
        public int tableId { get; set; }
    }


    
}