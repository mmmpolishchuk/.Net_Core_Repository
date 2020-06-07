using System.Collections.Generic;

namespace InfestationReports.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int SickCount { get; set; }
        public int DeadCount { get; set; }
        public int RecoveredCount { get; set; }
        public bool Vaccine { get; set; }

        public virtual List<Human> Humans { get; set; }
        public virtual WorldPart WorldPart { get; set; }
    }
}
