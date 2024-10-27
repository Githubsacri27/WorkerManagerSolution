using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkerManagementLibraryClass.Entidades;

namespace WorkerManagementLibraryClass.Metodos
{
    public class TeamManager
    {
        private List<ITWorker> Managers { get; set; } = new List<ITWorker>();
        private List<ITWorker> Technicians { get; set; } = new List<ITWorker>();
        public List<Team> teams = new List<Team>();
        private WorkerManager workerManager;

        public TeamManager(WorkerManager workerManager)
        {
            this.workerManager = workerManager;
        }

        // asignar un ITWorker como manager general
        public void AssignManager(int workerId)
        {
            var itWorker = workerManager.GetITWorkerById(workerId);
            if (itWorker == null)
            {
                Console.WriteLine("ITWorker not found.");
                return;
            }
            if (itWorker.Level != "Senior")
            {
                Console.WriteLine($"IT Worker {itWorker.Name} not have level (Senior) to be assigned as manager.");
                return;
            }

            Managers.Add(itWorker);
            Console.WriteLine($"IT Worker {itWorker.Name} assigned as manager.");
        }

        // asignar un ITWorker como technician general
        public void AssignTechnician(int workerId)
        {
            var itWorker = workerManager.GetITWorkerById(workerId);
            if (itWorker == null)
            {
                Console.WriteLine("ITWorker not found.");
                return;
            }

            Technicians.Add(itWorker);
            Console.WriteLine($"IT Worker {itWorker.Name} assigned as technician.");
        }

        // listar todos los Managers y Technicians
        public void ListTeamsMembersByName()
        {
            Console.WriteLine("Managers:");
            foreach (var manager in Managers)
            {
                Console.WriteLine($"- {manager.Name} {manager.Surname}");
            }

            Console.WriteLine("Technicians:");
            foreach (var technician in Technicians)
            {
                Console.WriteLine($"- {technician.Name} {technician.Surname}");
            }
        }
        // crear un nuevo equipo y añadirlo a la lista
        public void CreateTeam()
        {
            Console.WriteLine("Introduce the team name:");
            string teamName = Console.ReadLine().Trim();

            var team = new Team {Name = teamName};
            teams.Add(team);
            Console.WriteLine($"New team {team.Name}created successfully.");
        
        }
        public void ListAllTeams()
        {
            Console.WriteLine("List of Teams: ");

            if (teams.Count == 0)
            {
                Console.WriteLine("No teams registered.");
                return;
            }

            foreach (var team in teams)
            {
                Console.WriteLine($"Team Name: {team.Name}");

                Console.WriteLine("Managers");
                foreach (var manager in team.Managers)
                {
                    Console.WriteLine($"    - {manager.Name} {manager.Surname}");
                }

                Console.WriteLine("Technicians");
                foreach (var technician in team.Technicians)
                {
                    Console.WriteLine($"    - {technician.Name} {technician.Surname}");
                }
                Console.WriteLine("-------------------------------------------");
            }
        }

        public string GetTeamNameByWorkerId(int workerId)
        {
            foreach (var team in teams)
            {
                Console.WriteLine($"[DEBUG] Checking team: {team.Name}");

                bool isManager = team.Managers.Any(manager => manager.Id == workerId);
                bool isTechnician = team.Technicians.Any(tech => tech.Id == workerId);

                if (isManager)
                {
                    Console.WriteLine($"[DEBUG] ITWorker ID {workerId} found in Managers of team {team.Name}");
                    return team.Name;
                }
                if (isTechnician)
                {
                    Console.WriteLine($"[DEBUG] ITWorker ID {workerId} found in Technicians of team {team.Name}");
                    return team.Name;
                }
            }
            Console.WriteLine($"[DEBUG] ITWorker ID {workerId} not found in any team.");
            return null;
        }


    }
}
