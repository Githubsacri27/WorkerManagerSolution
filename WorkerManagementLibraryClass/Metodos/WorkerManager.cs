using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerManagementLibraryClass.Entidades;

namespace WorkerManagementLibraryClass.Metodos
{
    public class WorkerManager
    {
        private List<ITWorker> workers = new List<ITWorker>();


        // eliminar ITWorker
        public void UnregisterWorkerIt(int workerId)
        {
            var worker = workers.Find(w => w.Id == workerId);
            if (worker != null)
            {
                workers.Remove(worker);
                Console.WriteLine($"Worker {worker.Name} unregistered successfully.");
            }
            else
            {
                Console.WriteLine("Worker not found.");
            }
        }

        public ITWorker GetITWorkerById(int id)
        {
            return workers.Find(w => w.Id == id);
        }

        // para registrar un nuevo ITWorker
        public void RegisterITWorker()
        {
            Console.WriteLine("Introduce the IT Worker information:");

            

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Birthdate (yyyy-MM-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Leave Date (yyyy-MM-dd, optional): ");
            DateTime leaveDate;
            if (!DateTime.TryParse(Console.ReadLine(), out leaveDate))
            {
                leaveDate = DateTime.MaxValue; 
            }

            Console.Write(" Number of years of experience: ");
            int yearsOfExperience = int.Parse(Console.ReadLine());

            //Console.Write("Technical Knowledge (e.g., C#, SQL, etc.): ");
            //string techKnowledges = Console.ReadLine();
          
            Console.WriteLine("Enter technologies known (separate by commas): ");
            var techInput = Console.ReadLine();
            List<string> techKnowledges = techInput.Split(',')
                                                   .Select(t => t.Trim())
                                                   .Where(t => !string.IsNullOrEmpty(t))
                                                   .ToList();
            //validar Junior, Mid, or Senior
            string level;
            while (true)
            {
                Console.Write("Enter level (Junior, Mid, or Senior): ");
                level = Console.ReadLine().Trim();

                if (level == "Junior" || level == "Mid" || level == "Senior")
                {
                    break;
                }

                Console.WriteLine("Invalid level. Please enter 'Junior', 'Mid', or 'Senior'.");
            }

            // Crear y registrar el nuevo ITWorker
            var itWorker = new ITWorker(name, surname, birthDate, leaveDate, yearsOfExperience, techKnowledges, level);
            workers.Add(itWorker);
            Console.WriteLine($"IT Worker {itWorker.Name} {itWorker.Surname} registered successfully with ID {itWorker.Id}.");
        }

        public void ListAllITWorkers()
        {
            Console.WriteLine("List of ITWorkers:");
            foreach (var worker in workers)
            {
                Console.WriteLine($"ID: {worker.Id}, Name: {worker.Name} {worker.Surname}, Level: {worker.Level}");
            }
        }



    }
}
