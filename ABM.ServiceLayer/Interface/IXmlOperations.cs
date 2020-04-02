using AMB.Domain;
using System.Xml.Linq;

namespace ABM.ServiceLayer.Interface
{
    public interface IXmlOperations
    {
        (string XmlValid, string DeclarationCommand, string SiteId) XmlValidationOperation(XElement xElement, InputDocument checkConstraints);
    }
}
