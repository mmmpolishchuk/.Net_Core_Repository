using System.Collections.Generic;
using System.Linq;

namespace InfestationReports.Models.Repositories.HumanRepository
{
    public class SqlHumanRepository : IHumanRepository
    {
        private InfestationContext Context { get; }

        public SqlHumanRepository(InfestationContext context)
        {
            Context = context;
        }
        public IEnumerable<Human> GetAllHumans()
        {
            return Context.Humans;
        }

        public Human GetHuman(int id)
        {
            return Context.Humans.SingleOrDefault(human => human.Id == id);
            Context.SaveChanges();
        }

        public void CreateHuman(Human human)
        {
            Context.Humans.Add(human);
            Context.SaveChanges();
        }

        public void ModifyHuman(Human human)
        {
            Context.Humans.Update(human);
        }

        public void DeleteHuman(int id)
        {
            var humanToDelete = Context.Humans.SingleOrDefault(human => human.Id == id);
            Context.Humans.Remove(humanToDelete);
        }
    }
}
