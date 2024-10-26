using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Entidades
{
    public class Team
    {
        public List<ITWorker> Managers { get; set; }
        public List<ITWorker> Technicians { get; set; }
        public string Name { get; set; }

        public Team()
        {
            Managers = new List<ITWorker>();
            Technicians = new List<ITWorker>();
            Name = this.Name;
        }

    }
}
