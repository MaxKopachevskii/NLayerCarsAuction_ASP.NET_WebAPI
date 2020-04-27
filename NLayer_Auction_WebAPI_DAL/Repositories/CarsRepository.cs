using NLayer_Auction_WebAPI_DAL.EF;
using NLayer_Auction_WebAPI_DAL.Entities;
using NLayer_Auction_WebAPI_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Auction_WebAPI_DAL.Repositories
{
    public class CarsRepository : IRepository<Car>
    {
        AuctionDbContext db;

        public CarsRepository(AuctionDbContext context)
        {
            db = context;
        }

        public void Create(Car item)
        {
            db.Cars.Add(item);
        }

        public void Delete(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
            }
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }

        public void Update(Car item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
