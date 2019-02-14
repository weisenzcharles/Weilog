using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Weilog.Admin;
using Weilog.Admin.Controllers;
using Weilog.Services;
using Weilog.Tests;
using Assert = NUnit.Framework.Assert;

namespace Weilog.Admin.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest : TestsBase
    {
        private IUserService _userService;
        public override void SetUp()
        {
            //_userService = MockRepository.GenerateMock<IUserService>();
            base.SetUp();
        }

        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_userService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_userService);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_userService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
