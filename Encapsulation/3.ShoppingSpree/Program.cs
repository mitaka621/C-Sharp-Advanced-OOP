using ShoppingSpree;
try
{
    List<Person> people = new List<Person>();
    List<Product> products= new List<Product>();
    string[] input=Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
    foreach (var item in input)
    {
        string[] cmds = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

        people.Add(new Person(cmds[0], double.Parse(cmds[1])));
    }
    input = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
    foreach (var item in input)
    {
        string[] cmds = item.Split("=");

        products.Add(new Product(cmds[0], double.Parse(cmds[1])));
    }

    string cmd;
    while ((cmd=Console.ReadLine())!="END")
    {
        string[] cmds = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        people.FirstOrDefault(x => x.Name == cmds[0]).Buy(cmds[1],products);
    }

    foreach (var item in people)
    {
        Console.WriteLine(item.ToString());
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    
}