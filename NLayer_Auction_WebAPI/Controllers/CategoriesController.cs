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
    //Controller for interaction with categories
    public class CategoriesController : ApiController
    {
        AuctionService auctionService;
        public CategoriesController()
        {
            auctionService = new AuctionService();
        }

        //Get all categories
        public IEnumerable<CategoryViewModel> GetAll()
        {
            IEnumerable<CategoryDTO> phoneDtos = auctionService.GetAllCategories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(phoneDtos);
            return categories;
        }

        //Get category with id №
        public CategoryDTO Get(int id)
        {
            var category = auctionService.GetCategory(id);
            return category;
        }

        //Create new category
        [Authorize(Roles = "admin,manager")]
        [HttpPost]
        public IHttpActionResult Create([FromBody]CategoryViewModel category)
        {
            try
            {
                if (category != null)
                {
                    CategoryDTO _category = new CategoryDTO { Id = category.Id, Name = category.Name, Desc = category.Desc };
                    auctionService.CreateCategory(_category);
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

        //Edit category with id №
        [Authorize(Roles = "admin,manager")]
        [HttpPut]
        public IHttpActionResult Edit(int id,[FromBody]CategoryViewModel category)
        {
            try
            {
                if (category != null)
                {
                    CategoryDTO _category = new CategoryDTO { Id = category.Id, Name = category.Name, Desc = category.Desc };
                    auctionService.EditCategory(_category);
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
        
        //Delete Categories id №
        [Authorize(Roles = "admin,manager")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                auctionService.DeleteCategory(id);
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
