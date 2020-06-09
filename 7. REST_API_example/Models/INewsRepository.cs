using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Web.Http.OData;

namespace REST_API_example.Models
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews(bool isFake);
        void CreateNews(News news);
        void DeleteNews(int id);
        void MoveNews(int id, News anotherNews);
        void UpdateNews(int id, News news);
    }
}
