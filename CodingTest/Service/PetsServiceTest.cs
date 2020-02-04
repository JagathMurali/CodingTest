
using Coding;
using Coding.Models;
using CodingTest.MockHttpHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace CodingTest.Service
{
    public class PetsServiceTest
    {
        string url = "http://agl-developer-test.azurewebsites.net/people.json";
        [Fact]
        public async void CheckWhetherHelperReturningCorrectValue()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockConfig = new Mock<IConfiguration>();
            List<OwnerModel> serviceResponse = new List<OwnerModel>();
            var configuration = new HttpConfiguration();
            Mock<ILogger<PetsService>> mockLoggerService = new Mock<ILogger<PetsService>>();
            var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) => {
                request.SetConfiguration(configuration);
                var response = request.CreateResponse(HttpStatusCode.OK, serviceResponse);
                return Task.FromResult(response);
            });
            var client = new HttpClient();

            mockFactory.Setup(mock => mock.CreateClient(It.IsAny<string>())).Returns(client);

            IHttpClientFactory factory = mockFactory.Object;

            PetsService service = new PetsService(factory, mockLoggerService.Object, mockConfig.Object);

            var result = await service.GetOwnerPetsDetails();

            Assert.NotNull(result);
        }

        [Fact]
        public async void CheckWhetherHelperReturnsExceptionWhenUrlIsNotSet()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockConfig = new Mock<IConfiguration>();
            List<OwnerModel> serviceResponse = new List<OwnerModel>();
            var configuration = new HttpConfiguration();
            Mock<ILogger<PetsService>> mockLoggerService = new Mock<ILogger<PetsService>>();
            var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) => {
                request.SetConfiguration(configuration);
                var response = request.CreateResponse(HttpStatusCode.OK, serviceResponse);
                return Task.FromResult(response);
            });
            var client = new Mock<HttpClient>();

            mockFactory.Setup(mock => mock.CreateClient(It.IsAny<string>())).Throws(new Exception());
            //  client.Setup(_ => _.SendAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(new HttpResponseMessage());
    
            IHttpClientFactory factory = mockFactory.Object;

            PetsService service = new PetsService(factory, mockLoggerService.Object, mockConfig.Object);

            Task act() => service.GetOwnerPetsDetails(); await Assert.ThrowsAsync<Exception>(act);
        }
    }
}
