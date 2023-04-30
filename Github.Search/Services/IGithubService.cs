using static Github.Search.Models.GithubResults;

namespace Github.Search.Services
{
    public interface IGithubService
    {
        public Task<RepCollections> SearchByStringAsync(string text);
    }
}
