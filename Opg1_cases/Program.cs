// See https://aka.ms/new-console-template for more information
Opg1_cases.Football football = new Opg1_cases.Football();
bool close = false;
string goal = "";
int passes = 0;
ConsoleKey c_key;
do
{
    Console.Write("Tryk A for fodbold, tryk B for danse");
    c_key = Console.ReadKey().Key;
    Console.Clear();
} while (c_key != ConsoleKey.A && c_key != ConsoleKey.B);

if(c_key == ConsoleKey.B)
{
    string name = "";
    int points = 0;


    Console.Write("Skriv navnet på danser 1:");
    name = Console.ReadLine();
    Console.Write("Skriv hvor mange point danser 1: ");
    points = int.Parse(Console.ReadLine());
    Opg1_cases.Dancer dancer1 = new Opg1_cases.Dancer(name, points);


    Console.Write("Skriv navnet på danser 2:");
    name = Console.ReadLine();
    Console.Write("Skriv hvor mange point danser 2: ");
    points = int.Parse(Console.ReadLine());
    Opg1_cases.Dancer dancer2 = new Opg1_cases.Dancer(name, points);

    Console.WriteLine(dancer1.name + " & " + dancer2.name + " points: " + (dancer1+dancer2));
}

//Fodbold Console
if (c_key == ConsoleKey.A)
{
    do
    {
        Console.Write("Skriv mål, hvis der er mål: ");
        goal = Console.ReadLine();
        Console.Write("Skriv hvor mange afleveringer: ");
        passes = int.Parse(Console.ReadLine());
        Console.Write(football.WeCheerIfGoalOrPasses(goal, passes));
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            close = true;
        }
        else
        {
            close = false;
        }
    } while (close);
}
