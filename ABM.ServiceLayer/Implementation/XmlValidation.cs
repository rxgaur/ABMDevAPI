using ABM.ServiceLayer.Interface;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ABM.ServiceLayer.Implementation
{
    public class XmlValidation : IXmlValidation
    {
        public (bool IsSuccess, string ErrorMessage) XmlValidate(XElement xElement)
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var xsdImportFilepath = $"{currentDirectory}\\xml\\input.xsd";

                var settings = new XmlReaderSettings();
                settings.Schemas.Add(string.Empty, xsdImportFilepath);
                settings.ValidationType = ValidationType.Schema;

                var reader = XmlReader.Create(new StringReader(xElement.ToString()), settings);
                var document = new XmlDocument();
                document.Load(reader);

                var eventHandler = new ValidationEventHandler(ValidationEventHandler);

                document.Validate(eventHandler);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    //log error e.Message;
                    break;
                case XmlSeverityType.Warning:
                    //log Warning e.Message;
                    break;
            }
        }
    }
}
