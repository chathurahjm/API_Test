using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Test.model;
using API_Test.util;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace API_Test.testUtils
{
   [TestClass]
   public  class TestBase
    {
        protected RestClient Client;
        public static ExtentTest extentTest;
        public static ExtentReports extentReport;
        private UnitTestOutcome testOutcome;
        public TestContext TestContext { get; set; }


        [AssemblyInitialize]
        static public void TestSetUp(TestContext con)
        {
            extentReport = new ExtentReports();
            extentReport.AttachReporter(new ExtentHtmlReporter("../../testOutPut/ExecutionStatus.html"));

        }

        [TestInitialize]
        public void setup()
        {
            string baseUrl = Constants.BASE_PATH;
            Client = new RestClient(baseUrl);


           

        }

      

        public ProductData CreateNewSingleDataRecord()
        {
            var baseUrl = "https://api.restful-api.dev";
            var endpoint = "/objects";

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.Post);

            ProductData productData = new ProductData
            {
                name = "TestData_Dell XPS 13",
                data = new Data
                {
                    Color = "TestData_Mercury Silver",
                    Capacity = "999 GB",
                    Year =2021,
                    Price = 9999.9,
                    CPUModel = "Intel Core i7"
                }
            };

            request.AddJsonBody(productData);

            var response = client.Execute(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Unexpected status code");

            var jsonResponse = response.Content;

            ProductData product = JsonConvert.DeserializeObject<ProductData>(jsonResponse);
            return product;
        }

        [AssemblyCleanup]
        static public void closeReport()
        {
            extentReport.Flush();
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            var status = TestContext.CurrentTestOutcome.ToString();

            if (status == "Failed")
            {
                extentTest.Fail(status);
                
            }
            else if(status == "Passed")
            {
                extentTest.Pass(status);

            }



        }
    }
}
