using System.Collections.Generic;

namespace _3._MVC._NewsBase.Models.Repositories
{
    public class MockNewsRepository : INewsRepository
    {
        private static List<News> News = new List<News>
        {
            new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson", IsFake = true},
            new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorName = "Svetlana Sokolova", IsFake = true},
            new News { Id = 2, Title = "Scientists estimated the time of the vaccine invention: it is a summer of 2021", Text = "", AuthorName = "John Jones", IsFake = false},
            new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers", IsFake = false},
            new News { Id = 4, Title = "A new species were discovered in Africa: it is blue legless cat", Text = "", AuthorName = "Jimmy Felon", IsFake = true}
        };

        public IEnumerable<News> GetAllNews()
        {
            return News;
        }
    }
}
