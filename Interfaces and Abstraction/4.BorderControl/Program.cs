using BorderControl;

int n = int.Parse(Console.ReadLine());
List<IBuyer> entities = new List<IBuyer>();


for (int i = 0; i < n; i++)
{
    string[] cmds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (cmds.Length == 4)
    {
        entities.Add(new Citizen(cmds[0], int.Parse(cmds[1]), cmds[2], cmds[3]));
    }
    else

        entities.Add(new Rebel(cmds[0], int.Parse(cmds[1]), cmds[2]));
}


string input;
while ((input=Console.ReadLine())!="End")
{
    if (entities.Any(x => x.Name == input))
        entities.FirstOrDefault(x => x.Name == input).BuyFood();

}

Console.WriteLine(entities.Sum(x=>x.Food));