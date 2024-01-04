class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("There are two choices: ");
        Console.WriteLine("1. My implemenattion of generic collections");
        Console.WriteLine("2. Standart implementation of generic collections");
        Console.WriteLine("Write number of variant you choose: ");
        string input = Console.ReadLine();
        if (int.Parse(input) == 1) {
            new MyCollection().Run();
        } else if (int.Parse(input) == 2) {
            new StandartCollection().Run();
        }
    }

}