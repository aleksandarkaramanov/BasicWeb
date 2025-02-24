using Xunit; // Библиотека за тестирање
using Moq; // Библиотека за мокирање на зависности
using MediatR; // За да мокнеме ISender
using Microsoft.AspNetCore.Mvc; // За да провериме дали враќа OkObjectResult
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Application.Queries.Companies;
using WebApp.Core.Entities;
using WebApp.Api.Controllers;
using WebApp.Application.Commands.Companies;

namespace WebApi.Tests.Controller
{
    public class CompanyControllerTests
    {
        [Fact]
        public async Task GetAllCompanyAsync_ReturnsOkResult()
        {
            // Arrange - Подготвуваме лажни податоци
            var fakeCompanies = new List<CompanyEntity>
        {
            new CompanyEntity { CompanyId = 1, CompanyName = "Company A" },
            new CompanyEntity { CompanyId = 2, CompanyName = "Company B" }
        };

            var mockSender = new Mock<ISender>(); // Креираме Mock за ISender
            mockSender.Setup(s => s.Send(It.IsAny<GetAllCompaniesQuery>(), default))
                      .ReturnsAsync(fakeCompanies); // Кога Send() се повика, врати fakeCompanies

            var controller = new CompanyController(mockSender.Object); // Креираме Controller

            // Act - Го повикуваме методот
            var result = await controller.GetAllCompanyAsync();

            // Assert - Проверуваме дали враќа OK резултат
            var okResult = Assert.IsType<OkObjectResult>(result); // Дали е OkObjectResult?
            var returnCompanies = Assert.IsType<List<CompanyEntity>>(okResult.Value); // Дали е листа?
            Assert.Equal(2, returnCompanies.Count); // Дали има 2 компании?
        }
        [Fact]
        public async Task AddCompanyAsync_ReturnsOkResult()
        {
            // Arrange - Подготвуваме лажна компанија
            var fakeCompany = new CompanyEntity { CompanyId = 1, CompanyName = "Test Company" };

            var mockSender = new Mock<ISender>(); // Креираме Mock за ISender
            mockSender.Setup(s => s.Send(It.IsAny<AddCompanyCommand>(), default))
                      .ReturnsAsync(fakeCompany.CompanyId); // Кога Send() се повика, врати CompanyId = 1

            var controller = new CompanyController(mockSender.Object); // Креираме Controller

            // Act - Го повикуваме методот
            var result = await controller.AddCompanyAsync(fakeCompany);

            // Assert - Проверуваме дали враќа OK резултат со точен `CompanyId`
            var okResult = Assert.IsType<OkObjectResult>(result); // Дали е OkObjectResult?
            var returnCompanyId = Assert.IsType<int>(okResult.Value); // Дали е `int`?
            Assert.Equal(1, returnCompanyId); // Дали врати 1 како CompanyId?
        }
        [Fact]
        public async Task DeleteCompanyAsync_ReturnsOkResult()
        {
            // Arrange - Подготвуваме mock за ISender
            var mockSender = new Mock<ISender>();

            // Конфигурираме Send() за да не прави ништо и само да врати успешно Task
            mockSender.Setup(s => s.Send(It.IsAny<DeleteCompanyCommand>(), default))
                      .Returns(Task.CompletedTask);

            var controller = new CompanyController(mockSender.Object); // Креираме Controller

            // Act - Го повикуваме методот
            var result = await controller.DeleteCompanyAsync(1); // Бришеме компанија со ID = 1

            // Assert - Проверуваме дали резултатот е OkObjectResult
            Assert.IsType<OkResult>(result);
        }
    }
}
