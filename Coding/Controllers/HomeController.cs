using Coding.Helper.Interfaces;
using Coding.Models;
using Coding.Services.Interfaces;
using Coding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Coding.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;
        private IPetsService _petService;
        private IPetHelper _petHelper;
        public HomeController(IPetsService petService, IPetHelper petHelper, ILogger<HomeController> logger) {
            _petService = petService;
            _petHelper = petHelper;
            _logger = logger;
        }
        public async Task<ActionResult> Index()
        {
            OwnerViewModel ownerViewModel = new OwnerViewModel();
            try
            {
      
                List<OwnerModel> ownerList = new List<OwnerModel>();
                ownerList = await _petService.GetOwnerPetsDetails();
                ownerViewModel = _petHelper.GetOwnerViewModelByCat(ownerList);
            }catch(Exception ex)
            {
               
                _logger.LogError(ex.Message);
                return View("Error");
            }
            return View(ownerViewModel);
        }
    }
}
