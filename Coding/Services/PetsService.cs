using Coding.Models;
using Coding.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Coding
{
    public class PetsService : IPetsService
    {
        private string serviceUrl;
        private readonly IHttpClientFactory _httpClientFactory;
        private ILogger _logger;
        private IConfiguration _config;
        public PetsService(IHttpClientFactory clientFactor, ILogger<PetsService> logger, IConfiguration config)
        {
            _httpClientFactory = clientFactor;
            _logger = logger;
            _config = config;
        }

        public async Task<List<OwnerModel>> GetOwnerPetsDetails()
        {
            serviceUrl = _config["ApiUrl"];
            List<OwnerModel> ownerList = new List<OwnerModel>();
            var client = _httpClientFactory.CreateClient();
            if (!string.IsNullOrEmpty(serviceUrl))
            {
                try
                {
                    
                    var request = new HttpRequestMessage(HttpMethod.Get, serviceUrl);
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        ownerList = await response.Content.ReadAsAsync<List<OwnerModel>>();
                    }
                    else
                    {
                        _logger.LogError("Error GetOwnerPetsDetails :-  Api does return correct result");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error in GetOwnerPetsDetails " + ex.Message);
                    throw ex;
                }
            }
            
            return ownerList;
        }
    }
}
