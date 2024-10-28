using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Metodos.Interfaces
{
    /// <summary>
    /// para iniciar y asignar roles y permisos
    /// </summary>
    public interface IAuthenticator
    {
        (int workerId, string role, List<int> allowedOptions) Login();
    }
}
