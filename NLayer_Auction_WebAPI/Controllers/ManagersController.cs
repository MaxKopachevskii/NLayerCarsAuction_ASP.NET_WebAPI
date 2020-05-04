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
    //The controller that will be used by the manager to confirm / delete lots
    [Authorize(Roles = "manager")]
    public class ManagersController : ApiController
    {
        AuctionService auctionService;

        public ManagersController()
        {
            auctionService = new AuctionService();
        }

        //Method for receiving all lots that are awaiting confirmation
        public IEnumerable<CarViewModel> GetAll()
        {
            IEnumerable<CarDTO> phoneDtos = auctionService.GetAllUnCheckedCars();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var services = mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(phoneDtos);
            return services;
        }

        /*The method by which the manager can:
         - confirm the lot and go to the main list of lots (api/Manager/1/true)
         - remove the lot (api/Manager/1/false)*/
        [Route("api/Managers/{id}/{flag}")]
        [HttpPut]
        public IHttpActionResult CheckCar(int id, bool flag)
        {
            try
            {
                if (flag == true)
                {
                    auctionService.EditCarCheck(id, flag);
                    auctionService.Save();
                    return Ok();
                }
                if (flag == false)
                {
                    auctionService.DeleteCar(id);
                    auctionService.Save();
                    return Ok();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
