using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer_Auction_WebAPI.Controllers;

namespace Api_Test
{
    [TestClass]
    public class ControlllerTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void RegisterResultNotNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Register() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RegisterEqualIndexCshtml()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Register() as ViewResult;

            Assert.AreEqual("Register", result.ViewName);
        }
    }
}
