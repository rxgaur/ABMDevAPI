using ABM.ServiceLayer.Implementation;
using ABM.ServiceLayer.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;

namespace ABM.UnitTest
{
    [TestClass]
    public class XMLTests
    {
        private IXmlParse xmlParse;
        private XElement xDocument; 

        [TestInitialize]
        public void Setup()
        {
            xmlParse = new XmlParse(); 
            var currentDirectory = Directory.GetCurrentDirectory();
            var correctImportFilepath = $"{currentDirectory}\\xml\\CorrectInput.xml";
            xDocument = XElement.Load(correctImportFilepath);
        }

        [TestMethod]
        public void XMLParseGetAttribute()
        {
            var xmlAttributeResult = xmlParse.GetAttribute(xDocument);

            Assert.AreEqual("DEFAULT", xmlAttributeResult.Attribute);
            Assert.IsNull(xmlAttributeResult.ErrorMessage);
        }

        [TestMethod]
        public void XMLParseGetElement()
        {
            var xmlElementResult = xmlParse.GetElement(xDocument);

            Assert.AreEqual("DUB", xmlElementResult.Element);
            Assert.IsNull(xmlElementResult.ErrorMessage);
        }
    }
}
