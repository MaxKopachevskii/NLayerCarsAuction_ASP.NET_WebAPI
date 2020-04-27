using NLayer_Auction_WebAPI_DAL.EF;
using NLayer_Auction_WebAPI_DAL.Entities;
using NLayer_Auction_WebAPI_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Auction_WebAPI_DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        AuctionDbContext db;
        CarsRepository carsRepository;
        CategoriesRepository categoriesRepository;

        public UnitOfWork(string connectionString)
        {
            db = new AuctionDbContext(connectionString);
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (carsRepository == null)
                    carsRepository = new CarsRepository(db);
                return carsRepository;
            } 
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepository(db);
                return categoriesRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

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
