using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Entidades
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime LeaveDate { get; set; }

        public Worker( int id, string name, string surname, DateTime birthday, DateTime leaveDate)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
            this.LeaveDate = leaveDate;
        }
    } 
}
