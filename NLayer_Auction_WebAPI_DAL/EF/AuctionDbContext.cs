using NLayer_Auction_WebAPI_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Auction_WebAPI_DAL.EF
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }

        static AuctionDbContext()
        {
            Database.SetInitializer<AuctionDbContext>(new AuctionInitialaizer());
        }
        public AuctionDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class AuctionInitialaizer : DropCreateDatabaseAlways<AuctionDbContext>
    {
        protected override void Seed(AuctionDbContext db)
        {
            Category category1 = new Category { Name = "Седан", Desc = "У машини 4 двери , багажник среднего размера." };
            Category category2 = new Category { Name = "Купе", Desc = "Двухдверная машина , обычно спортивного характера." };
            Category category3 = new Category { Name = "Универсал", Desc = "Просторная машина с большим багажгиком." };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);
            db.SaveChanges();

            Car car1 = new Car { Name = "Nissan GT-R R34", ShortDesc = "10-е поколение Nissan Skyline", LongDesc = "10-е поколение Nissan Skyline было представлено в мае 1998 в кузовах R34 с большим акцентом на спортивность и соответствие новым экологическим нормам. В базовой модели GT двигатель RB20E был заменен на RB20DE, в последний раз использовавшийся на R32, но модернизированный (NEO). R34 GT с двигателем RB20DE NEO и 5-ступенчатой коробкой передач, стал лучшим по топливной экономичности среди 6-цилиндровых Skyline всех поколений. 5-ступенчатая автоматическая трансмиссия была исключена из этого поколения, взамен предлагалась 4-ступенчатая АКПП и Полный привод. Всего выпущено 67211 автомобилей (включая модели GT-R)", Price = 35000, Img = "https://i.pinimg.com/originals/f8/ce/11/f8ce115d738b6152891845b9d3e475cf.jpg", CategoryId = category2.Id, IsCheck = true };
            Car car2 = new Car { Name = "Toyota Supra Mk4", ShortDesc = "Четвёртое поколение Supra A80", LongDesc = "Четвёртое поколение Supra использует шасси модели JZZ30 Soarer (известна также как модель Lexus SC300/400). На него устанавливались двигатели 2JZ-GE (атмосферный, 225 л. с.) и 2JZ-GTE (турбо, 280 л. с. для Японии и Европы) Изначально стоял на Toyota Aristo или он же Lexus GS. Самый мощный устанавливаемый двигатель 2JZ-GTE выдавал 330 л. с. Серия двигателей 2JZ-GTE хорошо поддается доработкам, связанными с увеличением мощности.", Price = 38000, Img = "https://a.d-cd.net/478c4a1s-1920.jpg", CategoryId = category2.Id, IsCheck = true };
            Car car3 = new Car { Name = "Mitsubishi Lancer Evo 9", ShortDesc = "9 поколение Mitsubishi Lancer Evolution", LongDesc = "Mitsubishi Lancer Evolution IX поступил в продажу в Японии 3 марта 2005, в тот же день он был продемонстрирован широкой аудитории на Женевском автосалоне . Американцы увидели этот автомобиль на en: New York International Auto Show в апреле. Двухлитровый двигатель 4G63 имел технологию MIVEC и доработанную турбину, в результате модернизации мощность двигателя возросла до 291 лошадиной силы и 392 Hм крутящего момента.", Price = 15000, Img = "https://ag-spots-2016.o.auroraobjects.eu/2016/08/19/other/2880-1800-crop-mitsubishi-lancer-evolution-ix-c812219082016205907_1.jpg", CategoryId = category1.Id, IsCheck = true };
            Car car4 = new Car { Name = "Subaru Impreza WRX STI", ShortDesc = "Первое поколение Subaru WRX STI", LongDesc = "История данной модели начинается в далёком 1992 году, когда на замену Subaru Legacy в ралли пришла Impreza. Сначала был заключен договор с компанией ProDrive на модернизацию и обслуживание автомобилей, которые выступают на ралли. Затем, спустя два года был представлен седан от STI, который имел более яркую спортивную направленность, в том числе двигатель EJ207 280 л.с. усиленную подвеску, тормозную систему и ещё много разнообразных улучшений.", Price = 10000, Img = "https://autotuni.ru/uploads/posts/2014-04/1396527927_slammed-subaru-wagon-sti-impreza-wrx-rhd-1.jpg", CategoryId = category3.Id, IsCheck = true };
            Car car5 = new Car { Name = "Nissan GT-R R35", ShortDesc = "Cуперкар, выпускаемый компанией Nissan Motor.", LongDesc = "Представлен в качестве серийной модели на Токийском автосалоне 24 октября 2007 года, продажи начались в 2008 году в Японии, затем в США и Европе. В отличие от предшественников, выпускавшихся только для JDM и ограниченным тиражом поставлявшихся в Великобританию, имеется вариант с левым рулём.", Price = 80000, Img = "https://img3.goodfon.ru/wallpaper/nbig/b/ff/nissan-r35-gtr-vossen-wheels.jpg", CategoryId = category2.Id, IsCheck = true };
            Car car6 = new Car { Name = "BMW M5 F90", ShortDesc = "Cедан модельного ряда BMW М5 в шестом поколении", LongDesc = "Новый БМВ М5 возможно заказать с сентября 2017 года, а поставки начнутся уже весной 2018 года. Цена составляет — 117 900 евро. Так же будет доступна и ограниченная тиражом в 400 копий версия — BMW M5 First Edition, которая окрашена в темно-красный металлик BMW Individual Frozen Dark Red Metallic, имеет эксклюзивное оборудование и дороже на 19 500 евро от базовой модели.", Price = 95000, Img = "https://cdn-ds.com/stock/2019-BMW-M5-Competition-Akron-OH/seo/ECL2585-WBSJF0C53KB284735/sz_518083/w_1280/h_853/WBSJF0C53KB284735_a2c2d61c097a6bfe.jpg", CategoryId = category1.Id, IsCheck = true };

            db.Cars.Add(car1);
            db.Cars.Add(car2);
            db.Cars.Add(car3);
            db.Cars.Add(car4);
            db.Cars.Add(car5);
            db.Cars.Add(car6);
            db.SaveChanges();

            base.Seed(db);
        }
    }
}
