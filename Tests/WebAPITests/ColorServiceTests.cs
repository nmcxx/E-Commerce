using Common.Data;
using Common.Models;
using Common.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services.ColorService;
using Xunit;

namespace Tests.WebAPITests
{
    public class ColorServiceTests
    {

        private readonly Mock<IColorService> mock = new Mock<IColorService>();
        [Fact]
        public async void AddColor()
        {
            ColorViewModel colorViewModel = new ColorViewModel();
            colorViewModel.Id = 0;
            colorViewModel.Name = "red";
            Color color = new Color("red");
            mock.Setup(p => p.AddColor(color)).ReturnsAsync(new ColorViewModel());
            ColorController colorController = new ColorController(mock.Object);
            var result = await colorController.PostColor(color);
            Assert.Equal(colorViewModel, result);
        }
    }
}
