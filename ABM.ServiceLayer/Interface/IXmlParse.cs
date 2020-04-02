using System.Xml.Linq;

namespace ABM.ServiceLayer.Interface
{
    public interface IXmlParse
    {
        (string Attribute, string ErrorMessage) GetAttribute(XElement xmlElement);
        (string Element, string ErrorMessage) GetElement(XElement xmlElement);
    }
}
