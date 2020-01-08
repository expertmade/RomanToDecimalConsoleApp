using System;
//test
namespace RomanToDecimalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //print header desciption function
            DisplayHeader();

            //ask for User info and a welcome message
            string UserName = GetUserData();


            //Get player intenion towards the Demo
            bool isTheUserIntrested = IsTheUserIntrested();

            //  Main demo loop
            while (isTheUserIntrested == true)
            {
                Console.Clear();
                Console.WriteLine($" ok {UserName}");
                TypeTheText("Enter a Romain Number in All Caps ");

                //read the Roman number from user
                string RomanNumber = Console.ReadLine();
                int DecimalNumber = RomanToDecimalConverter(RomanNumber);

                TypeTheText($"The Value of '{RomanNumber}' in Decimal is : '{DecimalNumber}' ");
                Console.WriteLine();

                //
                TypeTheText("Do you wish to check for different Roman Number ? type  'yes' or 'no' ");
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

            TypeTheText($"we are out of the game {UserName}, Hope You have a Great Day :-)  !!!");
            Console.ReadLine();
        }



        //display metadata of the program
        static void DisplayHeader()
        {
            //Project Header Data
            string projectName, versionNumber, authorName;
            projectName = "Roaman to deciaml Conversion ";
            versionNumber = "1.0.1";
            authorName = "Balaji Kummari";

            //header styling and output 
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            TypeTheText($"Project Name: {projectName};");
            TypeTheText($"Version: {versionNumber};");
            TypeTheText($"Author Name: {authorName};");
            Console.ResetColor();
        }

        //acquire data from the user
        static string GetUserData()
        {
            //Get player name
            TypeTheText("Hey there! Your Name Please ?");
            string UserName = Console.ReadLine();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            TypeTheText($"Hello {UserName} Nice to Meet you !!!");
            Console.ResetColor();
            return UserName;
        }

        //to know if the user is intrested to see the demo or not 
        static bool IsTheUserIntrested()
        {
            TypeTheText(" Want to see my Task Demo? type  'yes' or 'no'  ");
            string playerChoice = Console.ReadLine();
            bool isUserIntrested;
            if (playerChoice == "yes")
            {
                Console.Clear();
                TypeTheText("Great!!! So The Demo us about converting a Roman number into a Decimal Number");
                Console.WriteLine(" go to http://tiny.cc/n1zfiz to see this list of Roman Numbers ");
                TypeTheText("once done hit Enter to Play... ");
                Console.ReadKey();
                isUserIntrested = true;
            }
            else
            {
                Console.Clear();
                TypeTheText("I Dont think So.(*^.^*) ");
                TypeTheText("So The Demo us about converting a Roman number into a Decimal Number");
                Console.WriteLine(" go to http://tiny.cc/n1zfiz to see this list of Roman Numbers ");
                TypeTheText("once done hit Enter to Play... ");
                Console.ReadKey();
                isUserIntrested = true;
            }
            Console.Clear();
            TypeTheText(" Ohkk... let me think... ");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            return isUserIntrested;
        }

        //  Print the passed string in typing effect
        static void TypeTheText(string textTobeTyped)
        {
            for (int i = 0; i < textTobeTyped.Length; i++)
            {
                Console.Write(textTobeTyped[i]);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        //returns the decimal value of particular roman character
        static int ValueOfRomanCharacter(string RomanCharacter)
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

        //return Decimal value of the passed roman Number
        static int RomanToDecimalConverter(string RomanNumber)
        {
            int LengthOfRomanNumber = RomanNumber.Length - 1;
            int DecimalNumber = 0;

            //ValueOfCharacter() function returns the decimal value of particular roman character
            DecimalNumber = +ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber, 1));

            //loop to add value if the preceeding roman is Of greater value
            // and subract if it is of lower value 
            while (LengthOfRomanNumber > 0)
            {
                if (ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber - 1, 1)) >= ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber, 1)))
                {
                    DecimalNumber += ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber - 1, 1));
                }

                if (ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber - 1, 1)) < ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber, 1)))
                {
                    DecimalNumber -= ValueOfRomanCharacter(RomanNumber.Substring(LengthOfRomanNumber - 1, 1));
                }
                LengthOfRomanNumber--;
            }

            return DecimalNumber;
        }

    }

}
