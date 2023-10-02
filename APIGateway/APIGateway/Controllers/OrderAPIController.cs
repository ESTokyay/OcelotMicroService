using Microsoft.AspNetCore.Mvc;


namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        [HttpPost]
        public string test()
        {
            return "Service Çalışıyor.";
        }
       
    }
}
