using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1_cases
{
    internal class UI
    {
        
        //Variabler
        Opg1_cases.Football football = new Opg1_cases.Football();
        string goal, name, username, pass = "";
        int passes, points = 0;
        ConsoleKey c_key;
        Opg1_cases.Account account = new Opg1_cases.Account();
        Opg1_cases.User user, newUser;
        public void Start()
        {
            //Tjekker om brugeren er logget ind
            if(user == null)
            {
                //Hvis ikke beder den om brugernavn og adgangskode
                do { 
                
                    Console.WriteLine("For at bruge programmets funktioner, bedes du logge ind.");
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    Console.Write("Pass: ");
                    pass = Console.ReadLine();
                    user = account.GetUser(username, pass);

                    Console.Clear();



                } while (user == null);
            }
            //Hvis brugeren er logget ind, hvis den start menuen
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
                //Beder om navnet på danser 1
                Console.Write("Skriv navnet på danser 1: ");
                name = Console.ReadLine();
                //Beder om, hvor mange points danser 1 skal have, og tjekker om det indtastede er et tal
                do
                {
                    Console.Write("Skriv hvor mange point danser 1: ");
                } while (!int.TryParse(Console.ReadLine(), out points));
                //Gammer danser 1 i en variabel
                Opg1_cases.Dancer dancer1 = new Opg1_cases.Dancer(name, points);

                //Beder og navnet på danser 2
                Console.Write("Skriv navnet på danser 2: ");
                name = Console.ReadLine();
                //Beder om, hvor mange points danser 2 skal have, og tjekker om det indtastede er et tal
                do
                {
                    Console.Write("Skriv hvor mange point danser 2: ");
                } while (!int.TryParse(Console.ReadLine(), out points));
                //Gemmer danser 2 i en variabel
                Opg1_cases.Dancer dancer2 = new Opg1_cases.Dancer(name, points);

                //Udskriver det samlet resultat ved brug af operator overload
                Console.WriteLine(dancer1.name + " & " + dancer2.name + " points: " + (dancer1 + dancer2));

                //Spørger om man vil forsætte, eller om man vil til start menuen
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
                //Spørger om der har været mål
                Console.Write("Skriv mål, hvis der er mål: ");
                goal = Console.ReadLine();
                //Spørger om hvor mange afleveringer der har været og tjekker om det indtastede er et tal
                do
                {
                    Console.Write("Skriv hvor mange afleveringer: ");
                } while (!int.TryParse(Console.ReadLine(), out passes));
                //Kører metoden GoalOrPasses
                Console.Write(football.GoalOrPasses(goal, passes));
                
                //Spørger om man ønsker at indtaste igen, eller om man vil til start menuen
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
                //Beder om den nye adgangskode
                Console.Write("Indtast det du ønsker at ændre dit password til: ");
                pass = Console.ReadLine();

                //Opretter en ny bruger
                newUser = new Opg1_cases.User(user.UserName, pass, user.UsedPassword);
                Console.Clear();
            //Tjekker om den nye adgangskode lever op til kravene
            } while (account.PassUsedBefore(user, pass) || !account.PassStrong(newUser));

            //Tilføjer den nye adgangskode til listen over brugerens brugte adgangskode
            List<string> usedPass = user.UsedPassword;
            usedPass.Add(pass);
            newUser = new Opg1_cases.User(user.UserName, pass, usedPass);
            account.UpdateUserInFile(user, newUser);
            Console.WriteLine("Password ændret!");

            //Gemmer den nye user i user variblen
            user = newUser;

            //Går til start menuen
            Start();
        }
    }
}
