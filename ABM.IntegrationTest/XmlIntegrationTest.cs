using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

namespace ABM.IntegrationTest
{
    [TestClass]
    public class XmlIntegrationTest : TestClientProvider
    {
        [TestMethod]
        public void ApiSmokeTest()
        {
            using var request = new HttpRequestMessage(new HttpMethod("GET"), @"/IeImport");
            using var client = new TestClientProvider().Client;
            var response = client.SendAsync(request).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void ApiXmlTest()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var xsdImportFilepath = $"{currentDirectory}\\xml\\input.xml";
            var xDocument = XElement.Load(xsdImportFilepath);

            using var request = new HttpRequestMessage(new HttpMethod("POST"), @"/IeImport")
            {
                Content = new StringContent(xDocument.ToString(), Encoding.UTF8, "application/xml")
            };
            using var client = new TestClientProvider().Client;
            var response = client.SendAsync(request).Result;
 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("The XLM is valid if(0)  = 0, The Command is valid if (0), otherwise (-1)   = 0, The Command is valid if (0), otherwise (-2)   = 0", response.Content.ReadAsStringAsync().Result);
        }
    }
}
