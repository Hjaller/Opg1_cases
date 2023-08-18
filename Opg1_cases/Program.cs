﻿// See https://aka.ms/new-console-template for more information
Opg1_cases.Football football = new Opg1_cases.Football();
bool close = false;
string goal, username, pass = "";
int passes = 0;
ConsoleKey c_key;
Opg1_cases.Account account = new Opg1_cases.Account();
Opg1_cases.User user, newUser;
do
{
    Console.WriteLine("For at bruge programmets funktioner, bedes du logge ind.");
    Console.Write("Username: ");
    username = Console.ReadLine();
    Console.Write("Pass: ");
    pass = Console.ReadLine();
    user = account.GetUser(username, pass);




} while (user == null);



do
{

    Console.WriteLine("Velkommen tilbage " + user.UserName);
    Console.WriteLine("Hvis du ønsker at opdatere dit password, tryk O");
    Console.WriteLine("Hvis du ønsker at prøve danse programmet, tryk B");
    Console.WriteLine("Hvis du ønsker at prøve fodbold programmet, tryk A");
    c_key = Console.ReadKey().Key;

} while (c_key != ConsoleKey.A && c_key != ConsoleKey.B && c_key != ConsoleKey.O);


if (c_key == ConsoleKey.O)
{ 
    do
    {

        Console.Clear();
        Console.WriteLine("Indtast det du ønsker at ændre dit password til: ");
        pass = Console.ReadLine();

        newUser = new Opg1_cases.User(user.UserName, pass, user.UsedPassword);

    } while (account.PassUsedBefore(user, pass) || !account.PassStrong(newUser));
}


List<string> usedPass = user.UsedPassword;
usedPass.Add(pass);
newUser = new Opg1_cases.User(user.UserName, pass, usedPass);
account.UpdateUserInFile(user, newUser);
Console.WriteLine("Password ændret!");

user = newUser;


if(c_key == ConsoleKey.B)
{
    string name = "";
    int points = 0;


    Console.Write("Skriv navnet på danser 1:");
    name = Console.ReadLine();
    Console.Write(name.Length + "Skriv hvor mange point danser 1: ");
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
