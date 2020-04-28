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
    public class CategoriesController : ApiController
    {
        AuctionService auctionService;
        public CategoriesController()
        {
            auctionService = new AuctionService();
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            IEnumerable<CategoryDTO> phoneDtos = auctionService.GetAllCategories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(phoneDtos);
            return categories;
        }

        public CategoryDTO Get(int id)
        {
            var category = auctionService.GetCategory(id);
            return category;
        }

        [HttpPost]
        public void Create([FromBody]CategoryViewModel category)
        {
            CategoryDTO _category = new CategoryDTO { Id = category.Id, Name = category.Name, Desc = category.Desc };
            auctionService.CreateCategory(_category);
            auctionService.Save();
        }

        [HttpPut]
        public void Edit(int id,[FromBody]CategoryViewModel category)
        {
            CategoryDTO _category = new CategoryDTO { Id = category.Id, Name = category.Name, Desc = category.Desc };
            auctionService.EditCategory(_category);
            auctionService.Save();
        }
    }
}
