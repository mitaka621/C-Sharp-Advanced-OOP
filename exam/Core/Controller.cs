using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Models.Robots;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        SupplementRepository supplements;
        RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName == "DomesticAssistant")
            {
                robots.AddNew(new DomesticAssistant(model));
                return $"{typeName} {model} is created and added to the RobotRepository.";
            }
            else if (typeName == "IndustrialAssistant")
            {
                robots.AddNew(new IndustrialAssistant(model));
                return $"{typeName} {model} is created and added to the RobotRepository.";
            }
            else
                return $"Robot type {typeName} cannot be created.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName == "SpecializedArm")
            {
                supplements.AddNew(new SpecializedArm());
                return $"{typeName} is created and added to the SupplementRepository.";
            }
            else if (typeName == "LaserRadar")
            {
                supplements.AddNew(new LaserRadar());
                return $"{typeName} is created and added to the SupplementRepository.";
            }
            else
            {
                return $"{typeName} is not compatible with our robots.";
            }
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var supportedRobots = robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard)).ToList();
            if (!supportedRobots.Any())
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            supportedRobots = supportedRobots.OrderByDescending(x => x.BatteryLevel).ToList();
            double sum = supportedRobots.Sum(x => x.BatteryLevel);

            if (sum< totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - sum} more power needed.";
            }
            int counter = 0;
            while (totalPowerNeeded > 0)
            {
                foreach (var robot in robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard)).OrderByDescending(x=>x.BatteryLevel).ToList())
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {

                        robot.ExecuteService(totalPowerNeeded);                     
                        counter++;
                        return $"{serviceName} is performed successfully with {counter} robots.";
                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        counter++;
                        
                    }
                }
            }
            return $"{serviceName} is performed successfully with {counter} robots.";
        }

        public string Report()
        {
           var modifiedRobots=robots.Models().OrderByDescending(x=>x.BatteryLevel).ThenBy(x=>x.BatteryCapacity).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in modifiedRobots)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            int count = 0;

            foreach (var item in robots.Models().Where(x=>x.Model==model&&x.BatteryLevel*100/x.BatteryCapacity<50))
            {
                item.Eating(minutes);
                count++;
            }
            return $"Robots fed: {count}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supliment = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            var supportedRobots = robots.Models().Where(x => !x.InterfaceStandards.Contains(supliment.InterfaceStandard) && x.Model == model).ToList();
            if (!supportedRobots.Any())
            {
                return $"All {model} are already upgraded!";
            }


            robots.Models().First(x => x.GetType() == supportedRobots.First().GetType() && x.Model == supportedRobots.First().Model && supportedRobots.First().InterfaceStandards == x.InterfaceStandards).InstallSupplement(supliment);

            supplements.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";


        }
    }
}
