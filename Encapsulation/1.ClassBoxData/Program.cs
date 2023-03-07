using ClassBoxData;
try
{
    Box box = new Box(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

    Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
    Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
    Console.WriteLine($"Volume - {box.Volume():f2}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

