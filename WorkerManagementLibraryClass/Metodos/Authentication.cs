using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Metodos
{
    public class Authenticator
    {
        private WorkerManager workerManager;

        public Authenticator(WorkerManager workerManager)
        {
            this.workerManager = workerManager;
        }

        public int Login()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Please enter your Worker ID to log in:");

            if (!int.TryParse(Console.ReadLine(), out int workerId))
            {
                Console.WriteLine("Invalid ID format.");
                return Login(); 
            }

            // Verificar si es Admin (ID 0) o un ID válido en la lista de trabajadores
            if (workerId == 0 || workerManager.IsWorkerIdValid(workerId))
            {
                return workerId;
            }

            Console.WriteLine("Worker ID not found.");
            return Login(); 
        }
    }

}
