namespace Lab3
{
    public class Program
    {
       public static void Main(string[] args)
        {

            Console.Write("Please enter a month;");
            string month = Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter how many days there are in the month you gave;");
            Int32.TryParse(Console.ReadLine(), out int days);
            TemperatureInformation temperature = new TemperatureInformation(month, days);
            TemperatureData[] temperatureDataArray = temperature.GenerateRandomTemperaturesInMonth(days);
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("\tMeterology program\n\n\t[1] Average Temperature\n\t[2] ApexTemperatures\n" +
                    "\t[3] Sort Temperature\n\t[4] Warmetst day\n\t [5] Search by day\n\t " +
                    "[6] Most Common temperature\n\n\t [7] Exit Program\n");
                Int32.TryParse(Console.ReadLine(), out int userInput);
                switch (userInput)
                {
                    case 1: 
                        {
                            Console.Clear();
                            temperature.AverageTemperature(temperatureDataArray);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            temperature.ExtremaTemperature(temperatureDataArray);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            temperature.BubbleSort(temperatureDataArray);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            temperature.WarmDays(temperatureDataArray);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            temperature.SpecificDay(temperatureDataArray);
                            break;
                        }
                    case 6: 
                        {
                            Console.Clear();
                            temperature.MostCommonTemperature(temperatureDataArray);
                            break;
                        }
                    case 7:
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
    class TemperatureData
    {
        public int Days { get; private set; }
        public string Month { get; private set; }
        public int Temperature { get; private set; }

        public TemperatureData(string month, int days)
        {
            Month = month;
            Days = days;
            Temperature = Temperature;
        }
        public TemperatureData()
        {
            Month = Month;
            Days = Days;
            Temperature = Temperature;
        }
        public TemperatureData[] GenerateRandomTemperaturesInMonth(int days)
        {
            Random random = new Random();
            TemperatureData[] dataArray = new TemperatureData[days];
            int x = 1;
            for (int i = 0; i < days; i++)
            {
                TemperatureData tempData = new TemperatureData();
                tempData.Days = x++;
                tempData.Month = Month;
                tempData.Temperature = random.Next(0, 25 + 1);
                dataArray[i] = tempData;
            }
            return dataArray;
        }

    }
    class TemperatureInformation : TemperatureData
    {
        public TemperatureInformation(string month, int days) : base(month, days) { }

        public void AverageTemperature(TemperatureData[] temperatureArray)
        {
            int sumOfArray = 0;
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                sumOfArray += temperatureArray[i].Temperature;
            }
            int averageSumOfArray = sumOfArray / temperatureArray.Length;
            Console.Clear();
            Console.WriteLine($"\tThe average temperature in {Month} is: {averageSumOfArray}°C\n");
        }
        public void ExtremaTemperature(TemperatureData[] temperatureArray)
        {
            int extrema = temperatureArray[0].Temperature;
            string extremaStr = "";
            int userInput = MenuChoice("\tWhich extrema would you like to see?\n\n\t[1] Hottest \n\t[2] Coldest");
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (userInput == 0)
                {
                    if (temperatureArray[i].Temperature > extrema)
                    {
                        extrema = temperatureArray[i].Temperature;
                        extremaStr = "hottest";
                    }
                }
                else
                {
                    if (temperatureArray[i].Temperature < extrema)
                    {
                        extrema = temperatureArray[i].Temperature;
                        extremaStr = "coldest";
                    }

                }

            }
            Console.Clear();
            Console.WriteLine($"\tThe {extremaStr} temperature in {Month} is: {extrema}°C\n");
        }
        public void PrintArray(TemperatureData[] temperatureArray)
        {
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                Console.WriteLine($"{Month} {temperatureArray[i].Days} - {temperatureArray[i].Temperature}°C");
            }
        }
        public void BubbleSort(TemperatureData[] temperatureArray)
        {
            TemperatureData[] tempArray = temperatureArray;

            int userInput = MenuChoice("\tWhich way would you like to sort?\n\n\t[1] Ascending \n\t[2] Descending");
            int max = temperatureArray.Length - 1;
            for (int i = 0; i < max; i++)
            {
                int left = max - i;
                for (int j = 0; j < left; j++)
                {
                    int value1 = temperatureArray[j].Temperature;
                    int value2 = temperatureArray[j + 1].Temperature;
                    if (userInput == 0)
                    {
                        if (value1 > value2)
                        {
                            TemperatureData temp = temperatureArray[j];
                            temperatureArray[j] = temperatureArray[j + 1];
                            temperatureArray[j + 1] = temp;
                        }
                    }
                    else
                    {
                        if (value1 < value2)
                        {
                            TemperatureData temp = temperatureArray[j];
                            temperatureArray[j] = temperatureArray[j + 1];
                            temperatureArray[j + 1] = temp;
                        }
                    }


                }
            }
            PrintArray(temperatureArray);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            temperatureArray = tempArray;
            Console.Clear();
        }
        public void WarmDays(TemperatureData[] temperatureArray)
        {
            List<TemperatureData> WarmTemperatureList = new List<TemperatureData>();
            int userInput = 0;
            bool menu = true;
            while (menu)
            {
                Console.Write("\tEnter a temperature greater than 0! We will show you ever day that is warmer than your choice:");
                Int32.TryParse(Console.ReadLine(), out userInput);
                    if (userInput > 0)
                    {
                        Console.Clear();
                        menu = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\tPlease write a number.\n\n");
                    }                
            }
           
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (userInput <= temperatureArray[i].Temperature)
                {
                    WarmTemperatureList.Add(temperatureArray[i]);
                }

            }
            TemperatureData[] tempArray = new TemperatureData[WarmTemperatureList.Count];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = WarmTemperatureList[i];
            }
            Console.WriteLine($"\tThese are the temperatures that are {userInput}°C or warmer:\n\n");
            PrintArray(tempArray);
            AfterArrayWait();

        }
        public void SpecificDay(TemperatureData[] temperatureArray)
        {
            TemperatureData[] temp = new TemperatureData[3];
            int userInput = 0;
            bool menu = true;
            while (menu)
            {
                Console.Write( $"\tEnter a date between 1 - {temperatureArray.Length} and we will " +
                    $"show you the temperature for that day and its neighbouring days:");
                Int32.TryParse(Console.ReadLine(), out userInput);
                if (userInput > 0)
                {
                    Console.Clear();
                    menu = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\tPlease enter a valid date\n");
                }
            }
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (userInput == temperatureArray[i].Days)
                {
                    if (userInput == 1)
                    {
                        temp = new TemperatureData[2];
                        temp[0] = temperatureArray[i];
                        temp[1] = temperatureArray[i + 1];
                    }
                    else if (userInput == temperatureArray.Length)
                    {
                        temp = new TemperatureData[2];
                        temp[0] = temperatureArray[i - 1];
                        temp[1] = temperatureArray[i];
                    }
                    else
                    {
                        temp[0] = temperatureArray[i - 1];
                        temp[1] = temperatureArray[i];
                        temp[2] = temperatureArray[i + 1];
                    }
                  
                }
            }
            Console.WriteLine($"\tHere is {userInput} of {Month} and its neighbouring days\n");
            PrintArray(temp);
            AfterArrayWait();
        }
        public void MostCommonTemperature(TemperatureData[] temperatureArray)
        {
            int commonTemperatureCount = 0;
            int commonTemperatureValue = 0;
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                int currentTemp = temperatureArray[i].Temperature;
                int currentTempCount = 0;
                for (int j = 0; j < temperatureArray.Length; j++)
                {
                    if (currentTemp == temperatureArray[j].Temperature)
                    {
                        currentTempCount++;
                    }
                }
                if (currentTempCount > commonTemperatureCount)
                {
                    commonTemperatureCount = currentTempCount;
                    commonTemperatureValue = temperatureArray[i].Temperature;

                }
            }
            Console.Clear();
            Console.WriteLine($"\tThe most common temperature was: {commonTemperatureValue}°C and appeared {commonTemperatureCount} times\n");
            AfterArrayWait();
        }
        public int MenuChoice(string menuText)
        {
            int userInput = 0;
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine(menuText);

               Int32.TryParse(Console.ReadLine(), out userInput) ;
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
        public void AfterArrayWait()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    
    }   
  } 
    
    
