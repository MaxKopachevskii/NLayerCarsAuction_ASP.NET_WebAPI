using AutoMapper;
using NLayer_Auction_WebAPI.Models;
using NLayer_Auction_WebAPI_BLL.DTO;
using NLayer_Auction_WebAPI_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLayer_Auction_WebAPI.Controllers
{
    public class CarsController : ApiController
    {
        AuctionService auctionService;

        public CarsController()
        {
            auctionService = new AuctionService();
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllCheckedCars();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        public CarDTO Get(int id)
        {
            var car = auctionService.GetCar(id);
            return car;
        }

        [HttpPost]
        public void Create([FromBody]CarViewModel car)
        {
            var _car = new CarDTO { Id = car.Id, Name = car.Name, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Price = car.Price, Date = car.Date, Img = car.Img, IsCheck = car.IsCheck, UserName = car.UserName };
            auctionService.CreateCar(_car);
            auctionService.Save();
        }

        [HttpPut]
        public void Edit(int id, [FromBody]CarViewModel car)
        {
            var _car = new CarDTO { Id = car.Id, Name = car.Name, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Price = car.Price, Date = car.Date, Img = car.Img, IsCheck = car.IsCheck, UserName = car.UserName };
            auctionService.EditCar(_car);
            auctionService.Save();
        }

        public void Delete(int id)
        {
            auctionService.DeleteCar(id);
            auctionService.Save();
        }

        [Route("api/Cars/Sedan")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllSedans()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllSedans();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        [Route("api/Cars/Coupe")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllCoupes()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllCoupes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        [Route("api/Cars/Universal")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllUniversals()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllUniversals();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }
        //Vasserman`s commit
        //Какой-то трабл именно в обновлении обьекта
        //[Route("api/Cars/{id}/{rate}")]
        //[HttpPut]
        //public void MakeRate(int id, int rate)
        //{
        //    var car = auctionService.GetCar(id);
        //    var _car = new CarDTO { Id = car.Id, Name = car.Name, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Price = car.Price, Date = car.Date, Img = car.Img, IsCheck = car.IsCheck, UserName = car.UserName };
        //    if ((rate - car.Price) > 999)
        //    {
        //        _car.Price = rate;
        //        auctionService.EditCar(_car);
        //        auctionService.Save();
        //    }
        //}
    }
}
