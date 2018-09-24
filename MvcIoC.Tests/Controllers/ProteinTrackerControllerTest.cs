using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcIoC.Controllers;
using MvcIoC.Models;

namespace MvcIoC.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void WhenNothingHasHappenedTotalAndGoalAreZero()
        {
            ProteinTrackerController controller = new ProteinTrackerController(new StubTrackingService());

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(0, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }

        [TestMethod]
        public void WhenTotalIsNonZero_AndAmountAdded_TotalIsIncreased()
        {
            var service = new StubTrackingService();
            service.Total = 10;

            ProteinTrackerController controller = new ProteinTrackerController(service);

            ViewResult result = controller.AddProtein(15) as ViewResult;

            Assert.AreEqual(25, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }

        public class StubTrackingService : IProteinTrackingService
        {
            public int Total { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Goal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void AddProtein(int amount)
            {
                Total += amount;
            }
        }
    }
}
