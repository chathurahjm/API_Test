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
    public class updateProductDataTest: TestBase
    {
        [TestMethod]
        [DynamicData(nameof(GetUpdateProductDatla), DynamicDataSourceType.Method)]
        public void ValidateUpdateProductDetails(string nameFromCSV,Data dataFromCSV)
        {

            extentTest = extentReport.CreateTest("Validate Update Product");


            ProductData productData_BeforeUpdate, productData_TobeUpdate, productData_AfterUpdate;

            productData_BeforeUpdate = CreateNewSingleDataRecord();
            string originalProductID = productData_BeforeUpdate.Id;

            productData_TobeUpdate = new ProductData
            {
                name = nameFromCSV,
                data = new Data
                {
                    Color = dataFromCSV.Color,
                    Capacity = dataFromCSV.Capacity,
                    Year = dataFromCSV.Year,
                    Price = dataFromCSV.Price,
                    CPUModel = dataFromCSV.CPUModel
                }
            };

            var request = new RestRequest("/objects/" + originalProductID, Method.Put);
            request.AddJsonBody(productData_TobeUpdate);

            var response = Client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Wrong status code");

            string jsonResponse = response.Content;
            productData_AfterUpdate = JsonConvert.DeserializeObject<ProductData>(jsonResponse);

            Assert.AreEqual(nameFromCSV, productData_AfterUpdate.name, "Name is not matching");
            Assert.AreEqual(dataFromCSV.Year, productData_AfterUpdate.data.Year, "Year is not matching");
            Assert.AreEqual(dataFromCSV.Price, productData_AfterUpdate.data.Price, "Price is not matching");
            Assert.AreEqual(dataFromCSV.CPUModel, productData_AfterUpdate.data.CPUModel, "CPU Model is not matching");
            Assert.AreEqual(dataFromCSV.Color, productData_AfterUpdate.data.Color, "Color is not matching");
            Assert.AreEqual(dataFromCSV.Capacity, productData_AfterUpdate.data.Capacity, "Capacity is not matching");
            Assert.IsNotNull(productData_AfterUpdate.updatedAt, "Product Update At field is missing");
        }

        private static IEnumerable<object[]> GetUpdateProductDatla()
        {
            string csvFilePath = Constants.VALID_UPDATE_DATAFILE_PATH;
            return CsvReader.ReadDevicesFromCsv(csvFilePath);
        }

      
    }
}
