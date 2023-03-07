namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake a = new Cake("a");
            System.Console.WriteLine(a.Grams);
            System.Console.WriteLine(a.Calories);
            System.Console.WriteLine(a.Price);
        }
    }
}