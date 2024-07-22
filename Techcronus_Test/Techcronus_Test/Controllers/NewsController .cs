using Microsoft.AspNetCore.Mvc;
using Techcronus_Test.Models;
using Techcronus_Test.ServiceLayer;

namespace Techcronus_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> GetNews([FromBody] ApiKeyModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newsItems = await _newsService.FetchAndStoreNewsAsync(model.ApiKey);
                return Ok(newsItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
