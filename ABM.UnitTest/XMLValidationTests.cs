using ABM.ServiceLayer.Implementation;
using ABM.ServiceLayer.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;

namespace ABM.UnitTest
{
    [TestClass]
    public class XMLValidationTests
    {
        private IXmlValidation xmlValidation;

        [TestInitialize]
        public void Setup()
        {
            xmlValidation = new XmlValidation();
        }

        [TestMethod]
        public void XMLValidationCorrectXml()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var correctImportFilepath = $"{currentDirectory}\\xml\\CorrectInput.xml";
            var correctXDocument = XElement.Load(correctImportFilepath);

            var xmlValidatedResult = xmlValidation.XmlValidate(correctXDocument);

            Assert.AreEqual(true, xmlValidatedResult.IsSuccess);
            Assert.IsNull(xmlValidatedResult.ErrorMessage);
        }

        [TestMethod]
        public void XMLValidationInCorrectXml()
        {

            var currentDirectory = Directory.GetCurrentDirectory();
            var inCorrectImportFilepath = $"{currentDirectory}\\xml\\IncorrectInput.xml";
            var incorrectXDocument = XElement.Load(inCorrectImportFilepath);

            var xmlValidatedResult = xmlValidation.XmlValidate(incorrectXDocument);

            Assert.AreEqual(false, xmlValidatedResult.IsSuccess);
            Assert.IsNotNull(xmlValidatedResult.ErrorMessage);
        }
    }
}
