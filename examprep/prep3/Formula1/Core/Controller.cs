using Formula1.Core.Contracts;
using Formula1.Models.Car;
using Formula1.Models.Pilot;
using Formula1.Models.Race;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        PilotRepository pilotRepository;
        RaceRepository raceRepository;
        FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName) == null|| pilotRepository.Models.Any(x=>x.FullName== pilotName&&x.CanRace))
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            if (carRepository.FindByName(carModel) == null )
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilotRepository.FindByName(pilotName).AddCar(carRepository.FindByName(carModel));
            return $"Pilot {pilotName} will drive a {carRepository.FindByName(carModel).GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (pilotRepository.FindByName(pilotFullName) == null || pilotRepository.FindByName(pilotFullName).CanRace==false||raceRepository.FindByName(raceName).Pilots.Contains(pilotRepository.FindByName(pilotFullName)))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            raceRepository.FindByName(raceName).AddPilot(pilotRepository.FindByName(pilotFullName));
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }
            if (type == "Ferrari")
            {
                carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                return $"Car {type}, model {model} is created.";
            }
            else if (type == "Williams")
            {
                carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                return $"Car {type}, model {model} is created.";
            }
            else
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");

        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            pilotRepository.Add(new Pilot(fullName));
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            raceRepository.Add(new Race(raceName, numberOfLaps));
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
           
            foreach (var item in raceRepository.Models.Where(x=>x.TookPlace))
            {
                sb.AppendLine(item.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (raceRepository.FindByName(raceName).Pilots.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (raceRepository.FindByName(raceName).TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            int laps = raceRepository.FindByName(raceName).NumberOfLaps;

            var list = raceRepository.FindByName(raceName).Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(laps)).Take(3).ToList();
            raceRepository.FindByName(raceName).TookPlace = true;

            pilotRepository.FindByName(list[0].FullName).WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {list[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot { list[1].FullName} is second in the { raceName} race.");
            sb.AppendLine($"Pilot {list[2].FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
