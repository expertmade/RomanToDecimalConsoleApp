using System;

namespace RomanToDecimalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //print header desciption function
            Header();

            //ask for User info and a welcome message
            string UserName = UserData();


            //Get player intenion towards the Demo
            bool isTheUserIntrested = IsTheUserIntrested();

            //  Main demo loop
            while (isTheUserIntrested == true)
            {
                Console.Clear();
                Console.WriteLine($" ok {UserName}");


                textTyper("Enter a Romain Number in All Caps ");

                //read the Roman number from user in form of string
                string RomainNumber = Console.ReadLine();
                int LengthOfRomanNumber = RomainNumber.Length - 1;
                int DecimalNumber = 0;

                //ValueOfCharacter() function returns the decimal value of particular roman character
                DecimalNumber = +ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber, 1));

                //loop to add value if the preceeding roman is Of greater value
                // and subract if it is of lower value
                while (LengthOfRomanNumber > 0)
                {
                    if (ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber - 1, 1)) >= ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber, 1)))
                    {
                        DecimalNumber += ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber - 1, 1));
                    }

                    if (ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber - 1, 1)) < ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber, 1)))
                    {
                        DecimalNumber -= ValueOfCharacter(RomainNumber.Substring(LengthOfRomanNumber - 1, 1));
                    }
                    LengthOfRomanNumber--;
                }
                textTyper($"The Value of '{RomainNumber}' in Decimal is : '{DecimalNumber}' ");
                Console.WriteLine();
                textTyper("Do you wish to continue? type  'yes' or 'no' ");
                string PlayerchoiceToContinue = Console.ReadLine();
                if (PlayerchoiceToContinue == "yes")
                {
                    isTheUserIntrested = true;
                }
                if (PlayerchoiceToContinue == "no")
                {
                    isTheUserIntrested = false;
                }
                Console.Clear();
            }

            //textTyper() is used to print the passed stying with typing effect 
            textTyper($"we are out of the game {UserName}, Hope You have a Great Day :-)  !!!");
            Console.ReadLine();
        }

        //returns the decimal value of particular roman character
        static int ValueOfCharacter(string RomanCharacter)
        {
            return RomanCharacter switch
            {
                "I" => 1,
                "V" => 5,
                "X" => 10,
                "L" => 50,
                "C" => 100,
                "D" => 500,
                "M" => 1000,
                _ => 0,
            };
        }

        //display metadata of the program
        static void Header()
        {
            //Project Header Data
            string projectName, versionNumber, authorName;
            projectName = "Roaman to deciaml Conversion ";
            versionNumber = "1.0.1";
            authorName = "Balaji Kummari";

            //header styling and output 
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            textTyper($"Project Name: {projectName};");
            textTyper($"Version: {versionNumber};");
            textTyper($"Author Name: {authorName};");
            Console.ResetColor();
        }

        //acquire data from the user
        static string UserData()
        {
            //Get player name
            textTyper("Hey there! Your Name Please ?");
            string UserName = Console.ReadLine();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            textTyper($"Hello {UserName} Nice to Meet you !!!");
            Console.ResetColor();
            return UserName;
        }

        //to know if the user is intrested to see the demo or not 
        static bool IsTheUserIntrested()
        {
            textTyper(" Want to see my Task Demo? type  'yes' or 'no'  ");
            string playerChoice = Console.ReadLine();
            bool isUserIntrested;
            if (playerChoice == "yes")
            {
                Console.Clear();
                textTyper("Great!!! So The Demo us about converting a Roman number into a Decimal Number");
                Console.WriteLine(" go to http://tiny.cc/n1zfiz to see this list of Roman Numbers ");
                textTyper("once done hit Enter to Play... ");
                Console.ReadKey();
                isUserIntrested = true;
            }
            else
            {
                Console.Clear();
                textTyper("I Dont think So.(*^.^*) ");
                textTyper("So The Demo us about converting a Roman number into a Decimal Number");
                Console.WriteLine(" go to http://tiny.cc/n1zfiz to see this list of Roman Numbers ");
                textTyper("once done hit Enter to Play... ");
                Console.ReadKey();
                isUserIntrested = true;
            }
            Console.Clear();
            textTyper(" Ohkk... let me think... ");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            return isUserIntrested;
        }

        //  Print the passed string in typing effect
        static void textTyper(string textTobeTyped)
        {
            for (int i = 0; i < textTobeTyped.Length; i++)
            {
                Console.Write(textTobeTyped[i]);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }
    }

}