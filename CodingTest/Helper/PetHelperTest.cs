using Coding.Helper;
using Coding.Models;
using Coding.ViewModels;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingTest.Helper
{
    public class PetHelperTest
    {
        [Fact]
        public void Check_Whether_GetOwnerViewModelByCat_Returning_Correct_Value()
        {
            List<OwnerModel> ownerList = PrepareData();
            Mock<ILogger<PetHelper>> mockLoggerService = new Mock<ILogger<PetHelper>>();
            PetHelper helper = new PetHelper(mockLoggerService.Object);
            OwnerViewModel ownerViewModel =  helper.GetOwnerViewModelByCat(ownerList);

            Assert.NotNull(ownerViewModel);
            Assert.Equal(3, ownerViewModel.FemaleOwnerCatList.Count);
            Assert.Equal(2, ownerViewModel.MaleOwnerCatList.Count);
        }

        [Fact]
        public void Check_Whether_GetOwnerViewModelByCat_Returns_empty_viewModel()
        {
            List<OwnerModel> ownerList = null;
            Mock<ILogger<PetHelper>> mockLoggerService = new Mock<ILogger<PetHelper>>();
            PetHelper helper = new PetHelper(mockLoggerService.Object);
            OwnerViewModel ownerViewModel = helper.GetOwnerViewModelByCat(ownerList);

            Assert.NotNull(ownerViewModel);
            Assert.Null(ownerViewModel.MaleOwnerCatList);
            Assert.Null(ownerViewModel.FemaleOwnerCatList);
        }

        private List<OwnerModel> PrepareData()
        {
            List<OwnerModel> ownerList = new List<OwnerModel>();
            OwnerModel OwnerModelMale1 = new OwnerModel();
            OwnerModelMale1.Gender = "Male";
            OwnerModel OwnerModelMale2 = new OwnerModel();
            OwnerModelMale2.Gender = "Male";
            OwnerModel OwnerModelMale3 = new OwnerModel();
            OwnerModelMale3.Gender = "Male";
            OwnerModel OwnerModelFemale1 = new OwnerModel();
            OwnerModelFemale1.Gender = "Female";
            OwnerModel OwnerModelFemale2 = new OwnerModel();
            OwnerModelFemale2.Gender = "Female";
            OwnerModel OwnerModelFemale3 = new OwnerModel();
            OwnerModelFemale3.Gender = "Female";

            Pet pet1 = new Pet();
            pet1.Name = "sample1";
            pet1.Type = "Cat";
            Pet pet2 = new Pet();
            pet2.Name = "sample2";
            pet2.Type = "Dog";
            Pet pet3 = new Pet();
            pet3.Name = "sample3";
            pet3.Type = "Fish";
            Pet pet4 = new Pet();
            pet4.Name = "example4";
            pet4.Type = "Cat";
            Pet pet5 = new Pet();
            pet5.Name = "xample5";
            pet5.Type = "Dog";
            OwnerModelMale1.Pets = new List<Pet>();
            OwnerModelMale1.Pets.Add(pet1);
            OwnerModelMale1.Pets.Add(pet2);

            OwnerModelMale2.Pets = new List<Pet>();
            OwnerModelMale2.Pets.Add(pet4);

            OwnerModelFemale1.Pets = new List<Pet>();
            OwnerModelFemale1.Pets.Add(pet3);

            OwnerModelFemale2.Pets = new List<Pet>();
            OwnerModelFemale2.Pets.Add(pet5);
            OwnerModelFemale2.Pets.Add(pet4);
            OwnerModelFemale2.Pets.Add(pet1);

            OwnerModelFemale3.Pets = new List<Pet>();
            OwnerModelFemale3.Pets.Add(pet1);
            ownerList.Add(OwnerModelMale1);
            ownerList.Add(OwnerModelMale2);
            ownerList.Add(OwnerModelMale3);
            ownerList.Add(OwnerModelFemale1);
            ownerList.Add(OwnerModelFemale2);
            ownerList.Add(OwnerModelFemale3);
            return ownerList;
        }
    }
}
