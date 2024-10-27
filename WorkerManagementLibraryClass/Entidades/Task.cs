using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Entidades
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Technology { get; set; }
        public string Status { get; set; }
        public int? IdWorker { get; set; }

        public Task (int id, string description, string technology, string status, int? idworker = null)
        {
            this.Id = id;
            this.Description = description;
            this.Technology = technology;
            this.Status = status;
            this.IdWorker = idworker;
        }
    }
}
