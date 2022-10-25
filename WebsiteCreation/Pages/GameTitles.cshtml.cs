using System.Collections.Generic;
using WebsiteCreation.Models;
using WebsiteCreation.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebsiteCreation.Pages
{
    public class GameTitleModel : PageModel
    {
        private readonly ILogger<GameTitleModel> _logger;

        public GameTitleModel(ILogger<GameTitleModel> logger,
             JsonFileGTController gameService)
        {
            _logger = logger;
            GameService = gameService;
        }

        public JsonFileGTController GameService { get; }
        public IEnumerable<Title_List> Games { get; private set; }

        public void OnGet() => Games = GameService.GetGames();
    }
}
