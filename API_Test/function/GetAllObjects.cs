using API_Test.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.function
{
    class GetAllObjects
    {

      

        public bool IsAllObjectsHaveName(List<ProductData> produtDataObject)
        {
            bool isAllObjectsHaveName = true;
            foreach (ProductData productData in produtDataObject)
            {
                if (productData.name == null)
                {
                    isAllObjectsHaveName = false;
                    break;
                }
            }
            return isAllObjectsHaveName;
        }

        internal bool IsAllObjectsHaveId(List<ProductData> produtDataObject)
        {
            bool isAllObjectsHaveId = true;
            foreach (ProductData productData in produtDataObject)
            {
                if (productData.Id == null)
                {
                    isAllObjectsHaveId = false;
                    break;
                }
            }
            return isAllObjectsHaveId;

        }
    }
}
