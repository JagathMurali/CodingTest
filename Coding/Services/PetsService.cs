using Coding.Models;
using Coding.Services.Interfaces;
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
        private string serviceUrl = "http://agl-developer-test.azurewebsites.net/people.json";
        private readonly HttpClient _client;
        private ILogger _logger;
        public PetsService(HttpClient client, ILogger<PetsService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<List<OwnerModel>> GetOwnerPetsDetails()
        {
            List<OwnerModel> ownerList = new List<OwnerModel>();
            try
            {               
                var request = new HttpRequestMessage(HttpMethod.Get, serviceUrl);
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    ownerList = await response.Content.ReadAsAsync<List<OwnerModel>>();
                }
                else
                {
                    _logger.LogError("Error GetOwnerPetsDetails :-  Api does return correct result");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in GetOwnerPetsDetails " + ex.Message);
                throw ex;
            }
            return ownerList;
        }
    }
}
