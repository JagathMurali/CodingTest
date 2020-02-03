using Coding;
using CodingTest.MockHttpHandler;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.Http;
using Xunit;

namespace CodingTest.Service
{
    public class PetsServiceTest
    {
        [Fact]
        public async void CheckWhetherHelperReturningCorrectValue()
        {
            //Mock<ILogger<PetsService>> mockLoggerService = new Mock<ILogger<PetsService>>();

            //var handler = new Mock<MockHttpHandler.HttpClientHandler>();

            //handler.Setup(mock => mock.SendAsync(It.IsAny<string>(), It.IsAny<HttpContent>())).ReturnsAsync(new HttpResponseMessage());



            //PetsService service = new PetsService(handler.Object._client, mockLoggerService.Object);

            //var result = await service.GetOwnerPetsDetails();

            //Assert.NotNull(result);
        }
    }
}
