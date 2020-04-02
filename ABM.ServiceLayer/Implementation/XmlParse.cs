using ABM.ServiceLayer.Interface;
using System;
using System.Linq;
using System.Xml.Linq;

namespace ABM.ServiceLayer.Implementation
{
    public class XmlParse : IXmlParse
    {
        public (string Attribute, string ErrorMessage) GetAttribute(XElement xmlElement)
        {
            try
            {
                var attribute = xmlElement.Descendants("Declaration")
                               .Select(x => (string)x.Attribute("Command")).FirstOrDefault();
                return (attribute, null);
            }
            catch (Exception ex)
            {
                return (null, $"Error in Retrieving By Attribute {ex.Message}");
            }

        }

        public (string Element, string ErrorMessage) GetElement(XElement xmlElement)
        {
            try
            {
                var element = xmlElement.Descendants("DeclarationHeader")
                                .Select(x => (string)x.Element("SiteID")).FirstOrDefault();
                return (element, null);
            }
            catch (Exception ex)
            {
                return (null, $"Error in Retrieving By Attribute {ex.Message}");
            }
        }
    }
}
