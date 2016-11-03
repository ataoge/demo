using Microsoft.AspNetCore.Mvc;

namespace Ataoge.AspNetCore.Controllers
{
    [Route("test")]
    public class TestController
    {
        [HttpGetAttribute()]
        [Route("index")]
        public IActionResult Index()
        {
            return new ContentResult(){Content ="Success"};
        }
    }
}