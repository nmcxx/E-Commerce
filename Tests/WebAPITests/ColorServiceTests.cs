using AutoMapper;
using Common.Data;
using Common.Models;
using Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services.ColorService;
using Xunit;

namespace Tests.WebAPITests
{
    public class ColorServiceTests
    {

        //private readonly Mock<IColorService> mock = new Mock<IColorService>();
        //private readonly 
        private readonly Mock<ILogger<ColorService>> logger = new Mock<ILogger<ColorService>>();
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();

        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("Testing").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            if (await context.Color.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    context.Color.Add(new Color()
                    {
                        ID = i,
                        Name = "Mau " + i
                    });
                    await context.SaveChangesAsync();
                }
            }

            return context;
        }

        private async Task<ColorService> GetColorService()
        {
            var dbContext = await GetDatabaseContext();

            ColorService colorService = new ColorService(dbContext, logger.Object, mapper.Object);
            return colorService;
        }

        [Fact]
        public async void GetAllColor()
        {
            var dbContext = await GetDatabaseContext();

            ColorService colorService = new ColorService(dbContext, logger.Object, mapper.Object);

            var colors = await colorService.GetAllColor();

            Assert.NotNull(colors);
            //logger.Setup(p => p.LogTrace("test"));
            //context.Setup(p => p.Color)

            //mock.Setup(p => p.GetColorById(2)).ReturnsAsync(color);
            //mock.Setup(p => p.AddColor(color)).ReturnsAsync(new ColorViewModel());
            ////mock.Setup(p => p.GetColorById(2)).ReturnsAsync(color);
            //ColorController colorController = new ColorController(mock.Object);
            //var result = await colorController.PostColor(color);
            //Assert.True(color.Equals(result));

            //var result = await colorController.GetColor(2);


            //Assert.False(color.Equals(result.Value));


            //var result = await colorController.PostColor(color);
            //var a = result.Result as CreatedResult;
            //var b = result.Result as BadRequestResult;
            //Assert.NotNull(result.Result);
            //Assert.NotNull(b);
            //Assert.False(result.Equals(HttpStatusCode.Created));
            //Assert.False(result.Equals(HttpStatusCode.BadRequest));
            //Assert.False(result.Equals(HttpStatusCode.InternalServerError));
        }

        [Fact]
        public async void Add_SingleColor_ReturnsSameColor()
        {
            ColorService service = await GetColorService();

            Color color = new Color()
            {
                ID = 0,
                Name = "NULLdd"
            };

            var result = await service.AddColor(color);
            var status = result.Result as CreatedResult;
            Assert.NotNull(status);
            
        }

        [Fact]
        public async void Get_ColorById_ReturnsSameColorById()
        {
            ColorService service = await GetColorService();

            var result = await service.GetColorById(1);
            Assert.Equal(1, result.Value.ID);
            /////////// mong doi //////// dau ra
        }
    }
}
