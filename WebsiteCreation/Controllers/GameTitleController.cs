using System.Collections.Generic;
using WebsiteCreation.Models;
using WebsiteCreation.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebsiteCreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTitleController : ControllerBase
    {
        public GameTitleController(JsonFileGTController gameService) =>
            GameTitleService = gameService;

        public JsonFileGTController GameTitleService { get; }

        [HttpGet]
        public IEnumerable<Title_List> Get() => GameTitleService.GetGames();
        

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
          


            if (request?.GameId == null)
                return BadRequest();

            GameTitleService.AddRating(request.GameId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string GameId { get; set; }
            public int Rating { get; set; }
        }
    }
}
