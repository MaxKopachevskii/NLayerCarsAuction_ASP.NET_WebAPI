using NLayer_Auction_WebAPI_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Auction_WebAPI_BLL.Interfaces
{
    public interface IAuctionService
    {
        IEnumerable<CarDTO> GetAllCars();
        IEnumerable<CategoryDTO> GetAllCategories();
        CarDTO GetCar(int id);
        CategoryDTO GetCategory(int id);
        void CreateCar(CarDTO car);
        void EditCar(CarDTO car);
        void DeleteCar(int id);
        void CreateCategory(CategoryDTO category);
        void EditCategory(CategoryDTO category);
        void DeleteCategory(int id);
        void Save();
        void Dispose();
    }
}
