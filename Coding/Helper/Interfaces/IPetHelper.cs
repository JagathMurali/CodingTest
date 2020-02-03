using Coding.Models;
using Coding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Helper.Interfaces
{
    public interface IPetHelper
    {
        OwnerViewModel GetOwnerViewModelByCat(List<OwnerModel> ownerList);
    }
}
