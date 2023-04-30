using Github.Search.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Github.Search.Controllers
{
    public class GithubController : Controller
    {
        private readonly IGithubService service;

        public GithubController(IGithubService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            string searchText = form["SearchText"];

            if (searchText != string.Empty)
            {
                var reposList = await service.SearchByStringAsync(searchText);
                return Ok(reposList);
            }

            return NotFound("Empty String");
        }

    }
}
