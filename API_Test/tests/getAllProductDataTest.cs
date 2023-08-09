using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using API_Test.model;
using API_Test.function;
using API_Test.testUtils;

namespace API_Test.tests
{
   [TestClass]
    public class getAllProductDataTest : TestBase
    {
        [TestMethod]
        public void ValidateAllTheObjectsAreHavingID()
        {

            extentTest = extentReport.CreateTest("Validate All Products Have ID");
            var endpoint = "/objects";

            //var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.Get);

            var response = Client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "wrong status code");


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Response received successfully.");
                Console.WriteLine("Response content:");
                Console.WriteLine(response.Content);

                
                List<ProductData> produtDataObject = JsonConvert.DeserializeObject<List<ProductData>>(response.Content);

                GetAllObjects getAllObjects = new GetAllObjects();
                Assert.IsTrue(getAllObjects.IsAllObjectsHaveId(produtDataObject), "Not all the objects have ID");
               
                
            }
           
        }


        [TestMethod]
        public void ValidateAllTheObjectsAreHavingName()
        {
            extentTest = extentReport.CreateTest("Validate All Products Have Name");


            var endpoint = "/objects";

            var request = new RestRequest(endpoint, Method.Get);

            var response = Client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "wrong status code");


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Response received successfully.");
                Console.WriteLine("Response content:");
                Console.WriteLine(response.Content);


                List<ProductData> produtDataObject = JsonConvert.DeserializeObject<List<ProductData>>(response.Content);

                GetAllObjects getAllObjects = new GetAllObjects();
              
                Assert.IsTrue(getAllObjects.IsAllObjectsHaveName(produtDataObject), "Not all the objects have Name");



            }
           
        }


        [TestMethod]
        public void ValidateGetAllTheObject()
        {

            extentTest = extentReport.CreateTest("Validate All Products Object");

            var endpoint = "/objects";

            var request = new RestRequest(endpoint, Method.Get);

            var response = Client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Wrong status code");


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               

                List<ProductData> produtDataObject = JsonConvert.DeserializeObject<List<ProductData>>(response.Content);


                Assert.AreEqual("1", produtDataObject[0].Id);
                Assert.AreEqual("Google Pixel 6 Pro", produtDataObject[0].name,"Product name is wrong");
                Assert.IsNotNull(produtDataObject[0].data,"Data values are mising");
                Assert.AreEqual("Cloudy White", produtDataObject[0].data.Color,"Color is wrong");
                Assert.AreEqual("128 GB", produtDataObject[0].data.Capacity,"Capacity is wrong");
               


            }
            
        }
    }
}
