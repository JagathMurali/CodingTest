using Coding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Services.Interfaces
{
    public interface IPetsService
    {
        Task<List<OwnerModel>> GetOwnerPetsDetails();
    }
}
