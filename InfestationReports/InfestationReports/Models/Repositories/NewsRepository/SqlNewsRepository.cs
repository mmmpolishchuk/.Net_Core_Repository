using System.Collections.Generic;
using System.Linq;

namespace InfestationReports.Models.Repositories.NewsRepository
{
    public class SqlNewsRepository : INewsRepository
    {
        private InfestationContext _context { get;  }

        public SqlNewsRepository(InfestationContext context)
        {
            _context = context;
        }
        public IEnumerable<News> GetAllNews()
        {
            return _context.News;
        }
    }
}
