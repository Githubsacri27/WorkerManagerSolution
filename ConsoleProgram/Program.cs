using WorkerManagementLibraryClass.Metodos;

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
            WorkerManager workerManager = new WorkerManager();
            Authenticator authenticator = new Authenticator(workerManager);
            // Iniciar sesión y obtener el ID del trabajador
            int workerId = authenticator.Login();
            bool continuar = true;

            //Menu

            while (continuar)
            {
                Console.WriteLine("********************************************");
                Console.WriteLine("Welcome to Worker Manager");
                Console.WriteLine("Select one option please");
                Console.WriteLine("1 - Register new IT worker");
                Console.WriteLine("2 - Register new team");
                Console.WriteLine("3 - Register new task");
                Console.WriteLine("4 - List all team names");
                Console.WriteLine("5 - List team members by team name");
                Console.WriteLine("6 - List unassigned tasks");
                Console.WriteLine("7 - List task assignments by team name");
                Console.WriteLine("8 - Assign IT worker to a team as manager");
                Console.WriteLine("9 - Assign IT worker to a team as technician");
                Console.WriteLine("10 - Assign task to IT worker");
                Console.WriteLine("11 - Unregister IT worker");
                Console.WriteLine("12 - Exit");
                Console.WriteLine("********************************************");

                int options;
                if (!int.TryParse(Console.ReadLine(), out options) || options < 1 || options > 12)
                {
                    Console.WriteLine("Invalid options. Please select a valid option (1-12).");
                    continue;
                }
                switch (options)
                {
                    case 1:
                        Console.WriteLine("Introduce a new IT worker");
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
                        Console.Write("Enter the ITWorker ID for manager: ");
                        int workerIdManager = int.Parse(Console.ReadLine());
                        teamManager.AssignManager(workerIdManager);
                        break;
                    case 9:
                        Console.Write("Enter the ITWorker ID for technician: ");
                        int workerIdTechnician = int.Parse(Console.ReadLine());
                        teamManager.AssignTechnician(workerIdTechnician);
                        break;
                    case 10:
                        taskManager.AssignTaskToITWorker(workerManager, teamManager);
                        break;
                    case 11:
                        Console.Write("Enter the ITWorker ID to unregister: ");
                        int workerIdToUnregister = int.Parse(Console.ReadLine());
                        workerManager.UnregisterWorkerIt(workerIdToUnregister);
                        break;
                    case 12:
                        continuar = false;
                        break;
                }
                if (continuar)
                {
                    Console.WriteLine("Would you like to perform another operation? (y/n)");
                    string response = Console.ReadLine();
                    if (response != "y")
                    {
                        Console.WriteLine("Exiting..");
                        continuar = false;
                    }
                }
            }
            Console.WriteLine("Program finished.");
        }
    }
}
