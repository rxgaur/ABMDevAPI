using ABM.ServiceLayer.Interface;
using AMB.Domain;
using System.Xml.Linq;

namespace ABM.ServiceLayer.Implementation
{
    public class XmlOperations : IXmlOperations
    {
        private readonly IXmlValidation xmlValidation;
        private readonly IXmlParse xmlParse;

        public XmlOperations(IXmlValidation xmlValidation, IXmlParse xmlParse)
        {
            this.xmlValidation = xmlValidation;
            this.xmlParse = xmlParse;
        }

        public (string XmlValid, string DeclarationCommand, string SiteId) XmlValidationOperation(XElement xElement, InputDocument checkConstraints)
        {
            var validation = xmlValidation.XmlValidate(xElement);
            var validationResult = validation.IsSuccess == true ? "0" : validation.ErrorMessage;

            var declarationCommand = xmlParse.GetAttribute(xElement);
            var declarationCommandResult = declarationCommand.Attribute == checkConstraints.Command ? "0" : "-1";

            var site = xmlParse.GetElement(xElement);
            var siteResult = site.Element == checkConstraints.SiteId ? "0" : "-2";

            return (validationResult, declarationCommandResult, siteResult);
        }

    }
}
