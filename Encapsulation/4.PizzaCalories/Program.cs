using PizzaCalories;

try
{
    string input = Console.ReadLine();
    
    string name = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
    input = Console.ReadLine();
    string[] cmds2 = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Pizza pizza = new Pizza(name, new Dough(cmds2[1], cmds2[2], double.Parse(cmds2[3])));
    while ((input = Console.ReadLine()) != "END")
    {
        string[] cmds = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        pizza.AddTopping(new Topping(cmds[1], double.Parse(cmds[2])));
    }
    Console.WriteLine(pizza);
   
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
