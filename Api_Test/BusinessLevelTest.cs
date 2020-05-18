using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer_Auction_WebAPI.Models;
using NLayer_Auction_WebAPI_BLL.DTO;
using NLayer_Auction_WebAPI_BLL.Services;
using NLayer_Auction_WebAPI_DAL.Entities;
using NLayer_Auction_WebAPI_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Test
{
    [TestClass]
    public class BusinessLevelTest
    {

        [TestMethod]
        public void GetAllCarsTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAll());
            //Assert
            Assert.IsNotNull(target);
        }


        [TestMethod]
        public void GetCheckedCarsTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllChecked());
            //Assert
            Assert.IsNotNull(target);
        }


        [TestMethod]
        public void GetUncheckedCarsTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllUnChecked());
            //Assert
            Assert.IsNotNull(target);
        }


        [TestMethod]
        public void GetAllSedansTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllSedans());
            //Assert
            Assert.IsNotNull(target);

        }
        [TestMethod]
        public void GetAllCoupesTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllCoupes());
            //Assert
            Assert.IsNotNull(target);
        }


        [TestMethod]
        public void GetAllUniversalsTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllUniversals());
            //Assert
            Assert.IsNotNull(target);
        }


        [TestMethod]
        public void GetAllCategoriesTest()
        {
            //Arrange
            var Database = new UnitOfWork("DefaultConnection");
            //Act
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            var target = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
            //Assert
            Assert.IsNotNull(target);
        }
    }
}
