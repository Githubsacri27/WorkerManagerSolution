using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerManagementLibraryClass.Entidades;

namespace WorkerManagementLibraryClass.Metodos
{
    public class TaskManager
    {
        private List<WorkerManagementLibraryClass.Entidades.Task> tasks = new List<WorkerManagementLibraryClass.Entidades.Task>();


        public void RegisterTask()
        {
            Console.WriteLine("Introduce the Task information");

            Console.WriteLine("Id:");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Description:");

            string description = Console.ReadLine();

            Console.WriteLine("Technology:");

            string technology = Console.ReadLine();

            // validar To do, Doing, Done
            string status;
            while (true)
            {
                Console.Write("Enter Status (To do, Doing, or Done): ");
                status = Console.ReadLine().Trim();

                if (status == "To do" || status == "Doing" || status == "Done")
                {
                    break;
                }

                Console.WriteLine("Invalid status. Please enter 'To do', 'Doing', or 'Done'.");
            }

            //Console.WriteLine("Status:");

            //string status = Console.ReadLine();

            //Console.WriteLine("Idworker");

            //int idworker = int.Parse(Console.ReadLine());

            var newTask = new WorkerManagementLibraryClass.Entidades.Task(id, description, technology, status, null);
            tasks.Add(newTask);
            Console.WriteLine($"Task '{description}' registered successfully.");

        }
        public void ListUnassignedTasks()
        {
            Console.WriteLine("List of Tasks Unassigned:");
            foreach (var task in tasks)
            {
                if (task.IdWorker == null) 
                {
                    Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Technology: {task.Technology}, Status: {task.Status}");
                }
            }
        }

        // asignar una Task a un ITWorker
        public void AssignTaskToITWorker(WorkerManager workerManager, TeamManager teamManager)
        {
            Console.WriteLine("Chose the Task for assigning to an ITWorker");
            ListUnassignedTasks();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("ITWorker list:");
            workerManager.ListAllITWorkers();
            Console.WriteLine("--------------------------------------");

            // Solicitar el ID de la tarea
            Console.Write("Enter the Task ID to assign: ");
            int taskId = int.Parse(Console.ReadLine());

            // Buscar la tarea en la lista
            var taskToAssign = tasks.Find(t => t.Id == taskId && t.IdWorker == null);
            if (taskToAssign == null)
            {
                Console.WriteLine("Task not found or already assigned.");
                return;
            }

            // Solicitar el ID del ITWorker
            Console.Write("Enter the ITWorker ID to assign the task to: ");
            int workerId = int.Parse(Console.ReadLine());

            // Asignar la tarea al ITWorker
            taskToAssign.IdWorker = workerId;
            Console.WriteLine($"Task '{taskToAssign.Description}' assigned to ITWorker with ID {workerId} successfully.");
        }

        public void ListTasksByTeamName(TeamManager teamManager)
        {
            Console.WriteLine("List of Tasks Assigned by Team Name:");

            foreach (var team in teamManager.teams)
            {
                Console.WriteLine($"Team: {team.Name}");

                // Mostrar managers y verificar si tienen tareas asignadas
                Console.WriteLine("Managers:");
                foreach (var manager in team.Managers)
                {
                    Console.WriteLine($"- {manager.Name} {manager.Surname}");
                    var assignedTasks = tasks.Where(t => t.IdWorker == manager.Id).ToList();
                    foreach (var task in assignedTasks)
                    {
                        Console.WriteLine($"    Task ID: {task.Id}, Description: {task.Description}, Technology: {task.Technology}, Status: {task.Status}");
                    }
                }

                // Mostrar technicians y verificar si tienen tareas asignadas
                Console.WriteLine("Technicians:");
                foreach (var technician in team.Technicians)
                {
                    Console.WriteLine($"- {technician.Name} {technician.Surname}");
                    var assignedTasks = tasks.Where(t => t.IdWorker == technician.Id).ToList();
                    foreach (var task in assignedTasks)
                    {
                        Console.WriteLine($"    Task ID: {task.Id}, Description: {task.Description}, Technology: {task.Technology}, Status: {task.Status}");
                    }
                }
            }
        }








    }
}
