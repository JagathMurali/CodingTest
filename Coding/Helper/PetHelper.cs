using Coding.Helper.Interfaces;
using Coding.Models;
using Coding.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Helper
{
    public class PetHelper : IPetHelper
    {
        private ILogger _logger;
        public PetHelper(ILogger<PetHelper> logger)
        {
            _logger = logger;
        }

        public OwnerViewModel GetOwnerViewModelByCat(List<OwnerModel> ownerList)
        {
            OwnerViewModel ownerViewModel = new OwnerViewModel();
            try
            {
       
                if (ownerList != null)
                {
                    ownerViewModel.MaleOwnerCatList = ownerList.Where(x => x.Gender.ToLower() == Constants.GENDERMALE && x.Pets != null)
                                                        .SelectMany(y => y.Pets)
                                                        .Where(c => c.Type.ToLower() == Constants.PETTYPE).ToList();


                    ownerViewModel.FemaleOwnerCatList = ownerList.Where(x => x.Gender.ToLower() == Constants.GENDERFEMALE && x.Pets != null)
                                                        .SelectMany(y => y.Pets)
                                                        .Where(c => c.Type.ToLower() == Constants.PETTYPE).ToList();
                    ownerViewModel.MaleOwnerCatList = ownerViewModel.MaleOwnerCatList.OrderBy(x => x.Name).ToList();
                    ownerViewModel.FemaleOwnerCatList = ownerViewModel.FemaleOwnerCatList.OrderBy(x => x.Name).ToList();

                }               
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in GetOwnerViewModelByCat " + ex.Message);
                throw ex;
            }
            return ownerViewModel;
        }
    }
}
