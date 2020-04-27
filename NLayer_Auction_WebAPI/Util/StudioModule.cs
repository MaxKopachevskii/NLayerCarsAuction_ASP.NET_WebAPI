using Ninject.Modules;
using NLayer_Auction_WebAPI_BLL.Interfaces;
using NLayer_Auction_WebAPI_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayer_Auction_WebAPI.Util
{
    public class StudioModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuctionService>().To<AuctionService>();
        }
    }
}