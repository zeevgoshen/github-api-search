using Github.Search.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using static Github.Search.Models.GithubResults;

namespace Github.Search.Services
{
    public class GithubService : IGithubService
    {
        public async Task<RepCollections> SearchByStringAsync(string text)
        {
            return await searchGithub(text);
        }

        public async Task<RepCollections> searchGithub(string searchQuery)
        {
            try
            {
                var url = "https://api.github.com";
                using var client = new HttpClient();
                client.BaseAddress = new Uri(url);

                // Add headers for JSON format.

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Github.Search", "1"));

                // Get data response
                var response = await client.GetAsync("/search/repositories?q=" +searchQuery);

                RepCollections rep = new RepCollections();

                if (response.IsSuccessStatusCode)
                {
                    //// Parse the response body
                    var dataObjects = await response.Content.ReadAsStringAsync();

                    if (dataObjects != null)
                        rep = JsonSerializer.Deserialize<RepCollections>(dataObjects);
                }
                return rep;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
        
}
