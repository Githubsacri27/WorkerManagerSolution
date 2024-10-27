using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Entidades
{
    public class ITWorker : Worker
    {
        

        public int YearsOfExperience { get; set; }
        //public string TechKnowledges { get; set; }
        public List<string> TechKnowledges { get; set; } // meter en una lista las tecnologías
        public string Level { get; set; }

        public ITWorker(string name, string surname, DateTime birthDate, DateTime leaveDate, int yearsOfExperience, List<string> techKnowledges, string level)
            : base(name, surname, birthDate, leaveDate)
        {
            YearsOfExperience = yearsOfExperience;
            TechKnowledges = techKnowledges;
            Level = level;
        }

    }
   
}
