using AutoMapper;
using NLayer_Auction_WebAPI_BLL.DTO;
using NLayer_Auction_WebAPI_BLL.Interfaces;
using NLayer_Auction_WebAPI_DAL.Entities;
using NLayer_Auction_WebAPI_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Auction_WebAPI_BLL.Services
{
    public class AuctionService : IAuctionService
    {
        UnitOfWork Database { get; set; }

        public AuctionService()
        {
            Database = new UnitOfWork("DefaultConnection");
        }
        public void CreateCar(CarDTO car)
        {
            Car _car = new Car
            {
                Id = car.Id,
                Name = car.Name,
                ShortDesc = car.ShortDesc,
                LongDesc = car.LongDesc,
                Price = car.Price,
                Img = car.Img,
                Date = car.Date,
                IsCheck = car.IsCheck,
                UserName = car.UserName,
                CategoryId = car.CategoryId
            };
            Database.Cars.Create(_car);
        }

        public void CreateCategory(CategoryDTO category)
        {
            Category _category = new Category
            {
                Id = category.Id,
                Name = category.Name,
                Desc = category.Desc
            };
            Database.Categories.Create(_category);
        }

        public void DeleteCar(int id)
        {
            Database.Cars.Delete(id);
        }

        public void DeleteCategory(int id)
        {
            Database.Categories.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditCar(CarDTO car)
        {
            Car _car = new Car
            {
                Id = car.Id,
                Name = car.Name,
                ShortDesc = car.ShortDesc,
                LongDesc = car.LongDesc,
                Price = car.Price,
                Img = car.Img,
                Date = car.Date,
                IsCheck = car.IsCheck,
                UserName = car.UserName,
                CategoryId = car.CategoryId
            };
            Database.Cars.Update(_car);
        }
        
        public void EditCarPrice(int id,int price)
        {
            var car = Database.Cars.Get(id);
            if ((price - car.Price) > 999)
            {
                car.Price = price;
                Database.Cars.Update(car);
            }
        }

        public void EditCarCheck(int id, bool flag)
        {
            var car = Database.Cars.Get(id);
            car.IsCheck = flag;
            Database.Cars.Update(car);
        

        public void EditCategory(CategoryDTO category)
        {
            Category _category = new Category
            {
                Id = category.Id,
                Name = category.Name,
                Desc = category.Desc
            };
            Database.Categories.Update(_category);
        }

        public IEnumerable<CarDTO> GetAllCars()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAll());
        }

        public IEnumerable<CarDTO> GetAllCheckedCars()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllChecked());
        }


        public IEnumerable<CarDTO> GetAllUnCheckedCars()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllUnChecked());
        }

        public IEnumerable<CarDTO> GetAllSedans()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllSedans());
        }

        public IEnumerable<CarDTO> GetAllCoupes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllCoupes());
        }

        public IEnumerable<CarDTO> GetAllUniversals()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAllUniversals());
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public CarDTO GetCar(int id)
        {
            var car = Database.Cars.Get(id);
            return new CarDTO { Id = car.Id, Name = car.Name, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Price = car.Price, Img = car.Img, IsCheck = car.IsCheck, Date = car.Date, UserName = car.UserName, CategoryId = car.CategoryId };
        }

        public CategoryDTO GetCategory(int id)
        {
            var category = Database.Categories.Get(id);
            return new CategoryDTO { Id = category.Id, Name = category.Name, Desc = category.Desc };
        }

        public void Save()
        {
            Database.Save();
        }
    }
}
