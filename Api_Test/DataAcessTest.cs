using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer_Auction_WebAPI_DAL.EF;
using NLayer_Auction_WebAPI_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Test
{
    [TestClass]
    public class DataAcessTest
    {
        [TestMethod]
        public void GetCarFromDBTest()
        {
            //Arrange
            var context = new AuctionDbContext("DefaultConnection");
            var db = context;
            CarsRepository tmp = new CarsRepository(context);
            Assert.AreEqual(tmp.GetAll(), db.Cars);
        }


        [TestMethod]
        public void GetAllCheckedFromDBTest()
        {
            //Arrange
            var context = new AuctionDbContext("DefaultConnection");
            var db = context;
            CarsRepository tmp = new CarsRepository(context);
            var target = context.Cars.Where(item => item.IsCheck == true);
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void GetAllUnCheckedFromDBTest()
        {
            //Arrange
            var context = new AuctionDbContext("DefaultConnection");
            var db = context;
            CarsRepository tmp = new CarsRepository(context);
            var target = db.Cars.Where(item => item.IsCheck == false);
            Assert.IsNotNull(target);

        }


        [TestMethod]
        public void GetAllSedansFromDBTest()
        {
            //Arrange
            var context = new AuctionDbContext("DefaultConnection");
            var db = context;
            CarsRepository tmp = new CarsRepository(context);
            var target = db.Cars.Where(item => item.CategoryId == 1);
            Assert.IsNotNull(target);
        }
    }
}
