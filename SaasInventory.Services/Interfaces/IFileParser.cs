using SaasInventory.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasInventory.Services.Interfaces
{
    public interface IFileParser
    {
        Inventory ParseProducts(StreamReader fileData);
    }
}
