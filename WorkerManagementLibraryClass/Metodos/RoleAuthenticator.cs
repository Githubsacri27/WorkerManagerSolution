using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WorkerManagementLibraryClass.Metodos.Interfaces;

namespace WorkerManagementLibraryClass.Metodos
{
    /// <summary>
    /// Implementación de IAuthenticator que gestiona la autenticación y asignación de roles
    /// </summary>
    public class RoleAuthenticator : IAuthenticator
    {
        private readonly IRegister _register;

        public RoleAuthenticator(IRegister register)
        {
            _register = register;
        }

        public (int workerId, string role, List<int> allowedOptions) Login()
        {
            Console.WriteLine("Please enter your Worker ID to log in:");

            if (!int.TryParse(Console.ReadLine(), out int workerId))
            {
                Console.WriteLine("Invalid ID format.");
                return Login();
            }

            List<int> allowedOptions;
            string role;

            if (_register.IsAdmin(workerId))
            {
                role = "Admin";//Admin, se mostrarán todas las opciones
                allowedOptions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            }
            else if (_register.IsManager(workerId))
            {
                role = "Manager";// Manager se mostrarán las opciones 5, 6, 7, 9, 10 y 12
                allowedOptions = new List<int> { 5, 6, 7, 9, 10, 12 };
            }
            else if (_register.IsTechnician(workerId))
            {
                role = "Technician";// se mostrarán las opciones 6, 7, 10 y 12 para Technician
                allowedOptions = new List<int> { 6, 7, 10, 12 };
            }
            else
            {
                Console.WriteLine("Worker ID not found.");
                return Login();
            }

            return (workerId, role, allowedOptions);
        }
    }


}
