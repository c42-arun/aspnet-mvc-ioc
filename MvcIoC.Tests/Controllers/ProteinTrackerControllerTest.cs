using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcIoC.Controllers;

namespace MvcIoC.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void WhenNothingHasHappenedTotalAndGoalAreZero()
        {
            ProteinTrackerController controller = new ProteinTrackerController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(0, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }
    }
}
