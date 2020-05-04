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
    public class ManagersController : ApiController
    {
        AuctionService auctionService;

        public ManagersController()
        {
            auctionService = new AuctionService();
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllUnCheckedCars();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }
        
        [Route("api/Managers/{id}/{flag}")]
        [HttpPut]
        public void CheckCar(int id, bool flag)
        {
            if (flag == true)
            {
                auctionService.EditCarCheck(id, flag);
                auctionService.Save();
            }
            if (flag == false)
            {
                auctionService.DeleteCar(id);
                auctionService.Save();
            }
        }
    }
}
