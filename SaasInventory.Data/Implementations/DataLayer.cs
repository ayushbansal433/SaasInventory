using SaasInventory.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasInventory.Data.Implementations
{
    public class DataLayer : IDataLayer
    {
        // some private readonly method

        //constructor
        public DataLayer()
        {
            Console.WriteLine("Datalayer");
        }

        //GetAll
        public void Get()
        {
            Console.WriteLine("Datalayer=> Get");
        }

        //getParticular

        //Add


        // update


        //delete
    }
}
