using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagementLibraryClass.Metodos.Interfaces
{
    /// <summary>
    /// define el acceso a una opción del menú
    /// </summary>
    public interface IRole
    {
        bool HasAccessToOption(int option);
    }
}
