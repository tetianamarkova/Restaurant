using Kodisoft.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodisoft.DAL.Repositories
{
    public class TableRepository : GenericRepository<Tables>
    {
        public TableRepository(DbContext context) : base(context)
        {
        }
    }
}
