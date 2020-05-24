using System.Collections.Generic;

namespace _3._MVC._NewsBase.Models.Repositories
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews();
    }
}
