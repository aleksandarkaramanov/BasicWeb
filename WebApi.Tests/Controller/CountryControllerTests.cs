using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Api.Controllers;
using WebApp.Application.Commands.Countries;
using WebApp.Application.Queries.Countries;
using WebApp.Core.Entities;

namespace WebApi.Tests.Controller
{
    public class CountryControllerTests
    {
        [Fact]
        public async Task GetAllCountryAsync_ReturnsOkResult()
        {
            // Arrange - Подготвуваме mock за ISender
            var mockSender = new Mock<ISender>();

            // Подготвуваме примерни податоци за враќање
            var fakeCountries = new List<CountryEntity>
        {
            new CountryEntity { CountryId = 1, CountryName = "Macedonia" },
            new CountryEntity { CountryId = 2, CountryName = "Serbia" }
        };

            // Конфигурираме Send() за да врати фејк листа со земји
            mockSender.Setup(s => s.Send(It.IsAny<GetAllCountriesQuery>(), default))
                      .ReturnsAsync(fakeCountries);

            var controller = new CountryController(mockSender.Object); // Креираме Controller

            // Act - Го повикуваме методот
            var result = await controller.GetAllCountryAsync();

            // Assert - Проверуваме дали резултатот е OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CountryEntity>>(okResult.Value);

            // Проверуваме дали има точен број на земји
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task AddCountryAsync_ReturnsOkResult()
        {
            // Arrange - Подготвуваме mock за ISender
            var mockSender = new Mock<ISender>();

            // Подготвуваме примерен објект за земја
            var newCountry = new CountryEntity { CountryId = 1, CountryName = "Macedonia" };

            // Конфигурираме Send() да врати идентификатор
            mockSender.Setup(s => s.Send(It.IsAny<AddCountryCommand>(), default))
                      .ReturnsAsync(newCountry.CountryId);

            var controller = new CountryController(mockSender.Object); // Креираме контролер

            // Act - Го повикуваме методот
            var result = await controller.AddCountryAsync(newCountry);

            // Assert - Проверуваме дали резултатот е OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<int>(okResult.Value);

            // Проверуваме дали вратениот ID е точен
            Assert.Equal(1, returnValue);
        }
        [Fact]
        public async Task DeleteCountryAsync_ReturnsOkResult()
        {
            // Arrange - Подготвуваме mock за ISender
            var mockSender = new Mock<ISender>();

            // Конфигурираме Send() за командата да врати Task.CompletedTask (значи операцијата е успешна)
            mockSender.Setup(s => s.Send(It.IsAny<DeleteCountryCommand>(), default))
                      .Returns(Task.CompletedTask);

            var controller = new CountryController(mockSender.Object); // Креираме контролер

            // Act - Го повикуваме методот
            var result = await controller.DeleteCountryAsync(1); // Бришеме земја со ID 1

            // Assert - Проверуваме дали резултатот е OkResult
            Assert.IsType<OkResult>(result);
        }
    }
}
