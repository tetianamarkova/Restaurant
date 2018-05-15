using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodisoftTest.Models
{
    public class TableCoordinatesViewModel
    {
        public int SelectedTable { get; set; }
        public List<Tables> Tables { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
    }
}