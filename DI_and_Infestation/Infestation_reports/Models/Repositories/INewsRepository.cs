using System.Collections.Generic;

namespace Infestation_reports.Models.Repositories
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews();
    }
}
