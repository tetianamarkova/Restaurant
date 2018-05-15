using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodisoft.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private DbContext db;
        private MenuItemsRepository menuItemsRepository;
        private OrdersRepository ordersRepository;
        private PlacesRepository placesRepository;
        private StatusRepository statusRepository;
        private TableRepository tableRepository;

        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        public OrdersRepository Orders
        {
            get
            {
                if (ordersRepository == null)
                    ordersRepository = new OrdersRepository(db);
                return ordersRepository;
            }
        }

        public TableRepository Tables
        {
            get
            {
                if (tableRepository == null)
                    tableRepository = new TableRepository(db);
                return tableRepository;
            }
        }

        public MenuItemsRepository MenuItems
        {
            get
            {
                if (menuItemsRepository == null)
                    menuItemsRepository = new MenuItemsRepository(db);
                return menuItemsRepository;
            }
        }

        public PlacesRepository Places
        {
            get
            {
                if (placesRepository == null)
                    placesRepository = new PlacesRepository(db);
                return placesRepository;
            }
        }

        public StatusRepository Status
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }

        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
