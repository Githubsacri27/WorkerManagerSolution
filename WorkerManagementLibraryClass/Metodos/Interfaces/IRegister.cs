using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerManagementLibraryClass.Entidades;

namespace WorkerManagementLibraryClass.Metodos.Interfaces
{
    /// <summary>
    /// para identificar roles, y el registro de workers.
    /// </summary>
    public interface IRegister
    {
        void RegisterWorker(ITWorker worker);
        ITWorker GetWorkerById(int workerId);
        bool IsAdmin(int workerId);
        bool IsManager(int workerId);
        bool IsTechnician(int workerId);
    }
}
