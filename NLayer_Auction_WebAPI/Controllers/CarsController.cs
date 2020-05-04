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
    //Controller for interaction with cars
    public class CarsController : ApiController
    {
        AuctionService auctionService;

        public CarsController()
        {
            auctionService = new AuctionService();
        }

        //Get all list of cars
        public IEnumerable<CarViewModel> GetAll()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllCheckedCars();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        //Get car with id №
        public CarDTO Get(int id)
        {
            var car = auctionService.GetCar(id);
            return car;
        }

        //Create new car
        [Authorize]
        [HttpPost]
        public IHttpActionResult Create([FromBody]CarViewModel car)
        {
            try
            {
                if (car != null)
                {
                    var _car = new CarDTO { Id = car.Id, Name = car.Name, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Price = car.Price, Date = car.Date, Img = car.Img, IsCheck = car.IsCheck, UserName = car.UserName };
                    auctionService.CreateCar(_car);
                    auctionService.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Edit car with id №
        [Authorize(Roles = "admin,manager")]
        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]CarViewModel car)
        {
            try
            {
                if (car != null)
                {
                    var _car = new CarDTO { Id = car.Id, Name = car.Name, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Price = car.Price, Date = car.Date, Img = car.Img, IsCheck = car.IsCheck, UserName = car.UserName };
                    auctionService.EditCar(_car);
                    auctionService.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Delete car with id №
        [Authorize(Roles = "admin,manager")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                auctionService.DeleteCar(id);
                auctionService.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Get all cars from sedan category
        [Route("api/Cars/Sedan")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllSedans()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllSedans();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        //Get all cars from coupe category
        [Route("api/Cars/Coupe")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllCoupes()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllCoupes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        //Get all cars from universal category
        [Route("api/Cars/Universal")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllUniversals()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllUniversals();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        //The method allows you to bet on the lot
        [Route("api/Cars/{id}/{rate}")]
        [Authorize]
        [HttpPut]
        public IHttpActionResult MakeRate(int id, int rate)
        {
            try
            {
                auctionService.EditCarPrice(id, rate);
                auctionService.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
