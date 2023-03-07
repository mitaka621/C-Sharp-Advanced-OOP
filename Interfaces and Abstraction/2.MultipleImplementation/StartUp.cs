using Telephony;

string[] phoneNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

ICaller phone;
foreach (var item in phoneNums)
{
    if (item.Length == 7)

        phone = new StationaryPhone();
    else
        phone = new Smartphone();

    Console.WriteLine(phone.Call(item));
    
}

IBrowser browser=new Smartphone();
string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (var item in urls)
{
    Console.WriteLine(browser.SurfTheNet(item)) ;
}