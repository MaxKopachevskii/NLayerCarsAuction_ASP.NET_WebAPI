using NLayer_Auction_WebAPI_DAL.Entities;
using NLayer_Auction_WebAPI_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Auction_WebAPI_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CarsRepository Cars { get; }
        CategoriesRepository Categories { get; }
        void Save();
    }
}
