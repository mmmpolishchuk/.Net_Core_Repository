using System.Collections.Generic;

namespace InfestationReports.Models.Repositories.NewsRepository
{
    public class SqlNewsRepository : INewsRepository
    {
        private InfestationContext Context { get;  }

        public SqlNewsRepository(InfestationContext context)
        {
            Context = context;
        }
        public IEnumerable<News> GetAllNews()
        {
            return Context.News;
        }
        public void CreateNews(News news)
        {
            Context.News.Add(news);
            Context.SaveChanges();
        }
    }
}
