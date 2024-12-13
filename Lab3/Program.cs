namespace Lab3
{
    //Add a way to show the median of all the temperatures in May
     class Program
    {
       
        static void Main(string[] args)
        {
            //Generates a random temperature in each day in May
            TemperatureData.GenerateTemperatureData();
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("\tMeterology program\n\n\t[1] Average Temperature\n\t[2] Extrema Temperatures\n" +
                    "\t[3] Sort Temperature\n\t[4] Warmetst day\n\t[5] Search by day\n\t" +
                    "[6] Most Common temperature\n\t[7] Print List\n\t[8] Find Median\n\n\t [9] Exit Program\n");
                Int32.TryParse(Console.ReadLine(), out int userInput);
                switch (userInput)
                {
                    case 1: 
                        {
                            Console.Clear();
                            TemperatureInformation.AverageTemperature();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            TemperatureInformation.ExtremaTemperature();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            TemperatureInformation.BubbleSort();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            TemperatureInformation.WarmDays();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            TemperatureInformation.SpecificDay();
                            break;
                        }
                    case 6: 
                        {
                            Console.Clear();
                            TemperatureInformation.MostCommonTemperature();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            TemperatureInformation.PrintArray(TemperatureData.temperatureDataArray);
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            TemperatureInformation.FindMedian();
                            break;
                        }
                    case 9:
                        {
                            menu = false;
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid choice.");
                            break;
                        }
                    }
                }
            } 
        }
  
   
  } 
    
    
