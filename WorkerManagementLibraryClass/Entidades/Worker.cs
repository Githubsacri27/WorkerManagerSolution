using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Entidades
{
    public class Worker
    {
        private static int idCounter = 0; // contador static para generar id 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime LeaveDate { get; set; }

        public Worker( string name, string surname, DateTime birthday, DateTime leaveDate)
        {
            this.Id = ++idCounter; // Incrementa el contador y asigna el valor al Id
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
            this.LeaveDate = leaveDate;
        }
    } 
}
