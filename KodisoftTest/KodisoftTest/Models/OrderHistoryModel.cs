using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodisoftTest.Models
{
    public class OrderHistoryModel
    {
        public List<Tables> tables { get; set; }
        public List<Orders> orders { get; set; }
        public int SelectedTable { get; set; }
        public bool OpenedStatus { get; set; }
        public bool ClosedStatus { get; set; }
    }
}