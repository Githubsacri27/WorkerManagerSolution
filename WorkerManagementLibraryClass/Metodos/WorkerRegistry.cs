using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerManagementLibraryClass.Entidades;
using WorkerManagementLibraryClass.Metodos.Interfaces;

namespace WorkerManagementLibraryClass.Metodos
{
    /// <summary>
    /// gestiona el registro de ITWorkers
    /// </summary>
    public class WorkerRegistry : IRegister
    {
        public List<ITWorker> Workers { get; private set; } = new List<ITWorker>();

        public WorkerRegistry()
        {
            // ITWorkers Registardos
            RegisterWorker(new ITWorker("Ruben", "Sacristan", new DateTime(1985, 5, 24), DateTime.MaxValue, 10, new List<string> { "C#", "Angular", "Java" }, "Senior"));
            RegisterWorker(new ITWorker("Monica", "Lopez", new DateTime(1990, 8, 19), DateTime.MaxValue, 4, new List<string> { "Python", "PHP", "Laravel" }, "Mid"));
            RegisterWorker(new ITWorker("Juan", "Alonso", new DateTime(1995, 11, 12), DateTime.MaxValue, 6, new List<string> { "Mongo", "Express", "React" }, "Senior"));

        }
        public void RegisterWorker(ITWorker worker)
        {
            Workers.Add(worker);
        }

        public ITWorker GetWorkerById(int workerId)
        {
            return Workers.FirstOrDefault(w => w.Id == workerId);
        }

        public bool IsAdmin(int workerId)
        {
            return workerId == 0; // ID 0 es Admin
        }

        public bool IsManager(int workerId)
        {
            return Workers.Any(w => w.Id == workerId && w.Level == "Senior");
        }

        public bool IsTechnician(int workerId)
        {
            return Workers.Any(w => w.Id == workerId && (w.Level == "Mid" || w.Level == "Junior"));
        }
    }

}
