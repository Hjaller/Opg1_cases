using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1_cases
{
    internal class UI
    {

        Opg1_cases.Football football = new Opg1_cases.Football();
        string goal, name, username, pass = "";
        int passes, points = 0;
        ConsoleKey c_key;
        Opg1_cases.Account account = new Opg1_cases.Account();
        Opg1_cases.User user, newUser;
        public void Start()
        {
            if(user == null)
            {
                do
                {
                    Console.WriteLine("For at bruge programmets funktioner, bedes du logge ind.");
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    Console.Write("Pass: ");
                    pass = Console.ReadLine();
                    user = account.GetUser(username, pass);

                    Console.Clear();



                } while (user == null);
            }
            do
            {

                Console.WriteLine("Velkommen tilbage " + user.UserName);
                Console.WriteLine("Hvis du ønsker at opdatere dit password, tryk O");
                Console.WriteLine("Hvis du ønsker at prøve danse programmet, tryk B");
                Console.WriteLine("Hvis du ønsker at prøve fodbold programmet, tryk A");
                c_key = Console.ReadKey().Key;

                Console.Clear();

                if (c_key == ConsoleKey.A) Football();
                if (c_key == ConsoleKey.B) Dance();
                if (c_key == ConsoleKey.O) ChangePassword();


            } while (c_key != ConsoleKey.A && c_key != ConsoleKey.B && c_key != ConsoleKey.O);


        }

        public void Dance()
        {
            bool close = false;
            do
            {
                Console.Write("Skriv navnet på danser 1: ");
                name = Console.ReadLine();
                do
                {
                    Console.Write("Skriv hvor mange point danser 1: ");
                } while (!int.TryParse(Console.ReadLine(), out points));
                Opg1_cases.Dancer dancer1 = new Opg1_cases.Dancer(name, points);


                Console.Write("Skriv navnet på danser 2: ");
                name = Console.ReadLine();
                do
                {
                    Console.Write("Skriv hvor mange point danser 2: ");
                } while (!int.TryParse(Console.ReadLine(), out points));
                Opg1_cases.Dancer dancer2 = new Opg1_cases.Dancer(name, points);

                Console.WriteLine(dancer1.name + " & " + dancer2.name + " points: " + (dancer1 + dancer2));

                Console.Write("\nØnsker du at skrive nye indtastninger, tryk enter.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    close = true;
                }
                else
                {
                    close = false;
                }

                Console.Clear();
            } while (close);

            Start();
        }

        public void Football()
        {
            bool close = false;
            do
            {
                Console.Write("Skriv mål, hvis der er mål: ");
                goal = Console.ReadLine();
                Console.Write("Skriv hvor mange afleveringer: ");
                passes = int.Parse(Console.ReadLine());
                Console.Write(football.WeCheerIfGoalOrPasses(goal, passes));
                Console.Write("\nØnsker du at skrive nye indtastninger, tryk enter.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    close = true;
                }
                else
                {
                    close = false;
                }

                Console.Clear();

            } while (close);

            Start();
        }

        public void ChangePassword()
        {
            do { 
            
                Console.Write("Indtast det du ønsker at ændre dit password til: ");
                pass = Console.ReadLine();

                newUser = new Opg1_cases.User(user.UserName, pass, user.UsedPassword);
                Console.Clear();

            } while (account.PassUsedBefore(user, pass) || !account.PassStrong(newUser));

            List<string> usedPass = user.UsedPassword;
            usedPass.Add(pass);
            newUser = new Opg1_cases.User(user.UserName, pass, usedPass);
            account.UpdateUserInFile(user, newUser);
            Console.WriteLine("Password ændret!");

            user = newUser;

            Start();
        }
    }
}
