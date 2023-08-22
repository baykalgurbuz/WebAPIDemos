using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemos.Controllers.Data.Services;
using WebAPIDemos.Controllers.Data.ViewModels;

namespace WebAPIDemos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVm publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }
    }
}
