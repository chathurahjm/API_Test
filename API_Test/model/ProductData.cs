using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.model
{
   public  class ProductData
    {

        public string Id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }

    }
}
