using ABM.ServiceLayer.Interface;
using AMB.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace ABM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IeImportController : ControllerBase
    {
        private readonly IXmlOperations xmlOperations;

        public IeImportController(IXmlOperations xmlOperations)
        {
            this.xmlOperations = xmlOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody]XElement document)
        {
            var checkConstraints = new InputDocument { Command = "DEFAULT", SiteId = "DUB" };
            var result = xmlOperations.XmlValidationOperation(document, checkConstraints);
            var finalResult = $"The XLM is valid if(0)  = {result.XmlValid}, The Command is valid if (0), otherwise (-1)   = " +
                              $"{ result.DeclarationCommand}, The Command is valid if (0), otherwise (-2)   = {result.SiteId}";
            return Ok(finalResult);
        }
    }
}
