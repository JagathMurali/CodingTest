using Coding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.ViewModels
{
    public class OwnerViewModel
    {
        public List<Pet> MaleOwnerCatList { get; set; }
        public List<Pet> FemaleOwnerCatList { get; set; }
    }
}
