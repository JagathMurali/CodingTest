using Coding.Controllers;
using Coding.Helper.Interfaces;
using Coding.Models;
using Coding.Services.Interfaces;
using Coding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodingTest
{
    public class HomeControllerTest
    {
        [Fact]
        public async void Check_Whether_LoadPage_With_Correct_Data()
        {
            OwnerViewModel serviceResponse = new OwnerViewModel();

            serviceResponse.FemaleOwnerCatList = new List<Pet>();
            serviceResponse.MaleOwnerCatList = new List<Pet>();
            Pet pet1 = new Pet();
            pet1.Name = "Sample";
            pet1.Type = "Cat";

            Pet pet2 = new Pet();
            pet2.Name = "sample2";
            pet2.Type = "sample";

            Pet pet3 = new Pet();
            pet3.Name = "sample3";
            pet3.Type = "sample";

            serviceResponse.FemaleOwnerCatList.Add(pet1);
            serviceResponse.FemaleOwnerCatList.Add(pet2);
            serviceResponse.MaleOwnerCatList.Add(pet3);

            Mock<IPetsService> mockPetService = new Mock<IPetsService>();
            Mock<IPetHelper> mockPetHelper = new Mock<IPetHelper>();
            Mock<ILogger<HomeController>> mockLoggerService = new Mock<ILogger<HomeController>>();
            mockPetHelper.Setup(mock => mock.GetOwnerViewModelByCat(It.IsAny<List<OwnerModel>>())).Returns(serviceResponse);

            HomeController controller = new HomeController(mockPetService.Object, mockPetHelper.Object, mockLoggerService.Object);
            ActionResult result = await controller.Index();
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult.Model);
            var viewModel = viewResult.Model as OwnerViewModel;
            Assert.Equal(serviceResponse, viewModel);
        }

        [Fact]
        public async void Check_Whether_Exception_Returns_Correct_View()
        {
            Mock<IPetsService> mockPetService = new Mock<IPetsService>();
            Mock<IPetHelper> mockPetHelper = new Mock<IPetHelper>();
            Mock<ILogger<HomeController>> mockLoggerService = new Mock<ILogger<HomeController>>();
            mockPetHelper.Setup(mock => mock.GetOwnerViewModelByCat(It.IsAny<List<OwnerModel>>())).Throws(new Exception());
            HomeController controller = new HomeController(mockPetService.Object, mockPetHelper.Object, mockLoggerService.Object);
            ActionResult result = await controller.Index();
            var viewResult = result as ViewResult;
            Assert.Equal("Error", viewResult.ViewName);
        }
    }
}
