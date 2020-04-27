using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayer_Auction_WebAPI.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public bool IsCheck { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}