using System.Text.Json.Serialization;

namespace Github.Search.Models
{
    public class GithubResults
    {
        public class Repositories
        {
            public int total_count { get; set; }
            public bool incomplete_results { get; set; }
        }

        public class RepCollections
        {
            public int total_count { get; set; }
            public bool incomplete_results { get; set; }

            //private List<Repositories> repositories;

            //public List<Repositories> Repositories { get => this.repositories; set => this.repositories = value; }
        }
    }
}
