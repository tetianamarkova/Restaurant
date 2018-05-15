using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodisoft.DAL.Repositories
{
    public class PlacesRepository : GenericRepository<Places>
    {
        public PlacesRepository(DbContext context) : base(context)
        {
        }
    }
}
