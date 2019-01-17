using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Weilog.Core.Domain.Repositories;
using Weilog.Entities;
using Weilog.Tests;
using Weilog.Web;
using Weilog.Web.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Weilog.Services;

namespace Weilog.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest : TestsBase
    {
        private IUserService _userService;
        public override void SetUp()
        {
            _userService = MockRepository.GenerateMock<IUserService>();
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
