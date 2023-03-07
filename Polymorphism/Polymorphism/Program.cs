
using Vehicles;
string[] input ;
Vehicle car=null, truck=null, bus=null;
for (int i = 0; i < 3; i++)
{
    input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    switch (input[0])
    {
        case "Car":
            car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            break;
        case "Bus":
            bus = new Bus(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            break;
        case "Truck":

            truck = new Truck(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            break;

        
    }
}

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    input = Console.ReadLine().Split();
    try
    {
        switch (input[0])
        {
            case "Drive":
                if (input[1] == "Car")
                {
                    Console.WriteLine(car.Drive(double.Parse(input[2])));
                }
                else if (input[1] == "Truck")
                    Console.WriteLine(truck.Drive(double.Parse(input[2])));
                else
                    Console.WriteLine(bus.Drive(double.Parse(input[2])));
                break;
            case "DriveEmpty":
                Console.WriteLine(((Bus)bus).DriveEmpty(double.Parse(input[2])));
                break;
            default:
                if (input[1] == "Car")
                {
                    car.Refuel(double.Parse(input[2]));
                }
                else if (input[1] == "Truck")
                    truck.Refuel(double.Parse(input[2]));
                else
                    bus.Refuel(double.Parse(input[2]));
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    
    }
    

}

Console.WriteLine(car);
Console.WriteLine(truck);
Console.WriteLine(bus);