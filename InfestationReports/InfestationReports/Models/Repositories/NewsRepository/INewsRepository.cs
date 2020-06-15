using System.Collections.Generic;

namespace InfestationReports.Models.Repositories.NewsRepository
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews();
        public void CreateNews(News news);
    }
}
