using WorkerManagementLibraryClass.Metodos;
using WorkerManagementLibraryClass.Entidades;
using WorkerManagementLibraryClass.Metodos.Interfaces;


namespace ConsoleProgram
{
    /// <summary>
    /// Gestión del menu
    /// </summary>
    public class Program
    {
        static WorkerManager workerManager = new WorkerManager();
        static TeamManager teamManager = new TeamManager(workerManager);
        static TaskManager taskManager = new TaskManager();

        static void Main(string[] args)
        {
            IRegister register = new WorkerRegistry();
            IAuthenticator authenticator = new RoleAuthenticator(register);
            var (workerId, role, allowedOptions) = authenticator.Login();

            ShowMenu(workerId, role, allowedOptions);
        }

        static void ShowMenu(int workerId, string role, List<int> allowedOptions)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine($"Welcome, {role}. Please select an option:");

                // Mostrar solo las opciones permitidas para el rol
                Console.WriteLine("********************************************");
                if (allowedOptions.Contains(1)) Console.WriteLine("1 - Register new IT worker");
                if (allowedOptions.Contains(2)) Console.WriteLine("2 - Register new team");
                if (allowedOptions.Contains(3)) Console.WriteLine("3 - Register new task");
                if (allowedOptions.Contains(4)) Console.WriteLine("4 - List all team names");
                if (allowedOptions.Contains(5)) Console.WriteLine("5 - List team members by team name");
                if (allowedOptions.Contains(6)) Console.WriteLine("6 - List unassigned tasks");
                if (allowedOptions.Contains(7)) Console.WriteLine("7 - List task assignments by team name");
                if (allowedOptions.Contains(8)) Console.WriteLine("8 - Assign IT worker to a team as manager");
                if (allowedOptions.Contains(9)) Console.WriteLine("9 - Assign IT worker to a team as technician");
                if (allowedOptions.Contains(10)) Console.WriteLine("10 - Assign task to IT worker");
                if (allowedOptions.Contains(11)) Console.WriteLine("11 - Unregister IT worker");
                if (allowedOptions.Contains(12)) Console.WriteLine("12 - Exit");
                Console.WriteLine("********************************************");

                Console.WriteLine("Select an option:");
                if (!int.TryParse(Console.ReadLine(), out int option) || !allowedOptions.Contains(option))
                {
                    Console.WriteLine("Invalid or unauthorized option. Try again.");
                    continue;
                }

                // Ejecutar la acción según la opción seleccionada
                switch (option)
                {
                    case 1:
                        workerManager.RegisterITWorker();
                        break;
                    case 2:
                        teamManager.CreateTeam();
                        break;
                    case 3:
                        taskManager.RegisterTask();
                        break;
                    case 4:
                        teamManager.ListAllTeams();
                        break;
                    case 5:
                        teamManager.ListTeamsMembersByName();
                        break;
                    case 6:
                        taskManager.ListUnassignedTasks();
                        break;
                    case 7:
                        taskManager.ListTasksByTeamName(teamManager);
                        break;
                    case 8:
                        Console.Write("Enter ITWorker ID for manager: ");
                        int managerId = int.Parse(Console.ReadLine());
                        teamManager.AssignManager(managerId);
                        break;
                    case 9:
                        Console.Write("Enter ITWorker ID for technician: ");
                        int techId = int.Parse(Console.ReadLine());
                        teamManager.AssignTechnician(techId);
                        break;
                    case 10:
                        taskManager.AssignTaskToITWorker(workerManager, teamManager);
                        break;
                    case 11:
                        Console.Write("Enter ITWorker ID to unregister: ");
                        int unregisterId = int.Parse(Console.ReadLine());
                        workerManager.UnregisterWorkerIt(unregisterId);
                        break;
                    case 12:
                        continuar = false;
                        break;
                }
            }
        }
    }
}
