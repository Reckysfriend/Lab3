using System;
namespace Lab3
{  
        // A class that holds some repeative code that helps
       // with userInput and wait time after displaying arrays.  
    public static class TemperatureInformationSupport
    {
                // Lets the user view the displayed array before going
                // back to main menu. 
            public static void AfterArrayWait()
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
                // Repetative code that appears each time the user has
                // to make a one out of two choice for which way
                // to "sort" the array. 
            public static int MenuChoice(string menuText)
            {
                int userInput = 0;
                bool menu = true;
                while (menu)
                {
                    Console.WriteLine(menuText);
                    Int32.TryParse(Console.ReadLine(), out userInput);
                    switch (userInput)
                    {
                        case 1:
                            {
                                userInput -= 1;
                                menu = false;
                                break;
                            }
                        case 2:
                            {
                                userInput -= 1;
                                menu = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please enter a valid choice.");
                                break;
                            }
                    }
                }
                return userInput;
            }
    }
}
