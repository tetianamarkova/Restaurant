using Kodisoft.DAL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodisoftNinject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<Restaurant>().InSingletonScope();
        }
    }
}
