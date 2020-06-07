using System.Collections.Generic;
using System.Linq;

namespace InfestationReports.Models.Repositories.HumanRepository
{
    public class SqlHumanRepository : IHumanRepository
    {
        private InfestationContext _context { get; }

        public SqlHumanRepository(InfestationContext context)
        {
            _context = context;
        }
        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }

        public Human GetHuman(int id)
        {
            return _context.Humans.SingleOrDefault(human => human.Id == id);
        }

        public void CreateHuman(Human human)
        {
            _context.Humans.Add(human);
        }

        public void ModifyHuman(Human human)
        {
            _context.Humans.Update(human);
        }

        public void DeleteHuman(int id)
        {
            var humanToDelete = _context.Humans.SingleOrDefault(human => human.Id == id);
            _context.Humans.Remove(humanToDelete);
        }
    }
}
