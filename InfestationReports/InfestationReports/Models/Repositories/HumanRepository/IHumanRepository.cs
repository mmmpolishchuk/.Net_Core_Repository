using System.Collections.Generic;

namespace InfestationReports.Models.Repositories.HumanRepository
{
    public interface IHumanRepository
    {
        public List<Human> GetAllHumans();
        public Human GetHuman(int id);
        public void CreateHuman(Human human);
        public void ModifyHuman(Human human);
        public void DeleteHuman(int humanId);
    }
}
