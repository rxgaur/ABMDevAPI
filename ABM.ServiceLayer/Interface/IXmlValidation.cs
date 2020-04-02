using System.Xml.Linq;

namespace ABM.ServiceLayer.Interface
{
    public interface IXmlValidation
    {
        (bool IsSuccess, string ErrorMessage) XmlValidate(XElement xElement);
    }
}
