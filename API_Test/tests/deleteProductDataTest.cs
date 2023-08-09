using API_Test.model;
using API_Test.testUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.tests
{
    [TestClass]
    public class deleteProductDataTest: TestBase
    {
        [TestMethod]
        public void ValidateDeleteProductByID()
        {

            extentTest = extentReport.CreateTest("Validate Delete Product By ID");


            ProductData productData_NewlyCreated;

            productData_NewlyCreated = CreateNewSingleDataRecord();
            string originalProductID = productData_NewlyCreated.Id;

            var request = new RestRequest("/objects/" + originalProductID, Method.Delete);
            var response = Client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Wrong status code");

            string jsonResponse = response.Content;
            Console.WriteLine("Response: " + jsonResponse);
            Console.WriteLine("Object with id = " + originalProductID + " has been deleted.");
            Assert.IsTrue(jsonResponse.Contains(originalProductID + " has been deleted."), "Output message is not as expected");
        }
    }
}
