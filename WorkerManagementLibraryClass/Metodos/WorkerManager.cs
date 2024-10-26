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

        //Registro de nuevo it worker

        public void RegisterWorkerIt(int id, string name, string surname, DateTime birthDate, DateTime leaveDate, int yearsOfExperience, string techKnowledges, string level)
        {
            var itWorker = new ITWorker(id, name, surname, birthDate, leaveDate, yearsOfExperience, techKnowledges, level);
            workers.Add(itWorker);
            Console.WriteLine($"IT Worker {itWorker.Name} registered successfully.");
        }

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
        //// obtener todos los ITWorkers
        //public List<ITWorker> GetITWorkers()
        //{
        //    return workers;
        //}

        //// listar todos los ITWorkers
        //public void ListWorkers()
        //{
        //    foreach (var worker in workers)
        //    {
        //        Console.WriteLine($"ID: {worker.Id}, Name: {worker.Name} {worker.Surname}, Experience: {worker.YearsOfExperience} years, Tech Knowledge: {worker.TechKnowledges}, Level: {worker.Level}");
        //    }
        //}

        // para registrar un nuevo ITWorker
        public void RegisterITWorkerInteractively()
        {
            Console.WriteLine("Introduce the IT Worker information:");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

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
                leaveDate = DateTime.MaxValue; // Valor por defecto si no se proporciona una fecha
            }

            Console.Write(" Number of years of experience: ");
            int yearsOfExperience = int.Parse(Console.ReadLine());

            Console.Write("Technical Knowledge (e.g., C#, SQL, etc.): ");
            string techKnowledges = Console.ReadLine();

            Console.Write("Level (e.g., Junior, Mid, Senior): ");
            string level = Console.ReadLine();

            // Crear y registrar el nuevo ITWorker
            var itWorker = new ITWorker(id, name, surname, birthDate, leaveDate, yearsOfExperience, techKnowledges, level);
            workers.Add(itWorker);
            Console.WriteLine($"IT Worker {itWorker.Name} {itWorker.Surname} registered successfully.");
        }


    }
}
