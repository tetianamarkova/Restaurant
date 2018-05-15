using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodisoft.DAL.Repositories
{
    public class StatusRepository : GenericRepository<StatusList>
    {
        public StatusRepository(DbContext context) : base(context)
        {
        }
    }
}
