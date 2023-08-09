using API_Test.model;
using API_Test.testUtils;
using API_Test.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.tests
{
    [TestClass]
    public class addValidProductsTest: TestBase
    {

        [TestMethod]
        [DynamicData(nameof(GetValidProductData1), DynamicDataSourceType.Method)]
        public void validateAddNewPorducts(string name, Data data)
        {

            extentTest = extentReport.CreateTest("Validate Add New Porducts "+name);
            var endpoint = "/objects";


            var request = new RestRequest(endpoint, Method.Post);

            var newProduct = new ProductData
            {
                name = name,
                data = data
            };

            string jsonBody = JsonConvert.SerializeObject(newProduct);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            var response = Client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Wrong status code");

           
            Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                ProductData produtDataObject = JsonConvert.DeserializeObject<ProductData>(response.Content);

                Assert.AreEqual(name, produtDataObject.name);
                Assert.AreEqual(data.Year, produtDataObject.data.Year);
                Assert.AreEqual(data.Price, produtDataObject.data.Price);
                Assert.AreEqual(data.CPUModel, produtDataObject.data.CPUModel);
                Assert.AreEqual(data.Color, produtDataObject.data.Color);
                Assert.AreEqual(data.Capacity, produtDataObject.data.Capacity);
                Assert.IsNotNull(produtDataObject.createdAt);
              



            }
            
        }

        private static IEnumerable<object[]> GetValidProductData1()
        {
            string csvFilePath = Constants.VALID_DATAFILE_PATH;
            return CsvReader.ReadDevicesFromCsv(csvFilePath);
        }

       
    }
}
