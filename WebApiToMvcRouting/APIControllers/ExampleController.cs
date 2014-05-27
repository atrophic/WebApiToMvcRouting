using System.Web.Http;

namespace WebApiToMvcRouting.APIControllers
{
    [RoutePrefix("api/example")]
    public class ExampleController : ApiController
    {
        [HttpGet]
        [Route("MvcRoute")]
        public string MvcRoute()
        {
            return Url.Link("Default", new {Controller = "Other", Action = "Index"});
        }

        [HttpGet]
        [Route("ApiRoute")]
        public string ApiRoute()
        {
            return Url.Link("DefaultApi", new {Controller = "Example", Id = "MvcRoute"});
        }
    }
}
