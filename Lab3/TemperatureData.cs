using System;
using System.Security.Cryptography;
namespace Lab3
{
    public class TemperatureData
    {
        //Creates a static array that will be used in all
        // our functions.
        public static TemperatureData[] temperatureDataArray = new TemperatureData[31];
        public int Days { get; private set; }
        public string Month { get; private set; }
        public int Temperature { get; private set; }

        public TemperatureData()
        {
            // The month is always May hence its the
            // default value for all instances.
            Month = "May";
            Days = Days;
            Temperature = Temperature;
        }
        public static void GenerateTemperatureData()
        {
            Random random = new Random();
            //Creates a "temp" array to store the newly instanced
            // TemperatureData objects. 
            int x = 1;
            for (int i = 0; i < temperatureDataArray.Length; i++)
            {
                //Creates a blank TemperatureData
                TemperatureData tempData = new TemperatureData();
                //Adds a incremential day coutner.
                tempData.Days = x++;
                //Randomzies a temperature between 0 and 25
                tempData.Temperature = random.Next(0, 25 + 1);
                //Moves the TemperatureData into the array the program uses.
                TemperatureData.temperatureDataArray[i] = tempData;
            }
        }
    }
    class TemperatureInformation : TemperatureData
    {
        public TemperatureInformation() { }

        public static void FindAverageTemperature()
        {
            //Finds out the average temperature by summing all of 
            //them and deviding by how many days there are.
            int sumOfArray = 0;
            for (int i = 0; i < TemperatureData.temperatureDataArray.Length; i++)
            {
                sumOfArray += TemperatureData.temperatureDataArray[i].Temperature;
            }
            int averageSumOfArray = sumOfArray / TemperatureData.temperatureDataArray.Length;
            Console.Clear();
            Console.WriteLine($"\tThe average temperature in May is: {averageSumOfArray}°C\n");
        }
        public static void FindExtremaTemperature()
        {
            int extrema = TemperatureData.temperatureDataArray[0].Temperature;
            string extremaStr = "";
            //MenuChoice helps reduced large repetative code when the user
            //needs to choose between two options.
            int userInput = TemperatureInformationSupport.MenuChoice("\tWhich extrema would you like to see?\n\n\t[1] Hottest \n\t[2] Coldest");
            for (int i = 0; i < TemperatureData.temperatureDataArray.Length; i++)
            {
                //Checks which choice the user made and branches the code
                //based on that. 
                if (userInput == 0)
                {
                    if (TemperatureData.temperatureDataArray[i].Temperature > extrema)
                    {
                        extrema = TemperatureData.temperatureDataArray[i].Temperature;
                        extremaStr = "hottest";
                    }
                }
                else
                {
                    if (TemperatureData.temperatureDataArray[i].Temperature < extrema)
                    {
                        extrema = TemperatureData.temperatureDataArray[i].Temperature;
                        extremaStr = "coldest";
                    }
                }
            }
            Console.Clear();
            Console.WriteLine($"\tThe {extremaStr} temperature in May is: {extrema}°C\n");
        }
        public static void PrintArray(TemperatureData[] printArray)
        {
            //Our go to call function for looping through our
            //array and printing each value before or after 
            //modification. 
            for (int i = 0; i < printArray.Length; i++)
            {
                Console.WriteLine($"May {printArray[i].Days} - {printArray[i].Temperature}°C");
            }
            TemperatureInformationSupport.AfterArrayWait();
        }
        public static void SortArray()
        {
            //tempArray is inisialised here since it needs to be
            //ascessible outside of our loop. 
            TemperatureData[] tempArray = TemperatureData.temperatureDataArray;
            //MenuChoice helps reduced large repetative code when the user
            //needs to choose between two options.
            int userInput = TemperatureInformationSupport.MenuChoice("\tWhich way would you like to sort?\n\n\t[1] Ascending \n\t[2] Descending");
            int max = TemperatureData.temperatureDataArray.Length - 1;
            //Sorts the array by allowing the highest temperatures to move from left to right
            // or right to left if we are descending the order (BubbleSort).
            for (int i = 0; i < max; i++)
            {
                int left = max - i;
                for (int j = 0; j < left; j++)
                {
                    int value1 = TemperatureData.temperatureDataArray[j].Temperature;
                    int value2 = TemperatureData.temperatureDataArray[j + 1].Temperature;
                    if (userInput == 0)
                    {
                        if (value1 > value2)
                        {
                            TemperatureData temp = TemperatureData.temperatureDataArray[j];
                            TemperatureData.temperatureDataArray[j] = TemperatureData.temperatureDataArray[j + 1];
                            TemperatureData.temperatureDataArray[j + 1] = temp;
                        }
                    }
                    else
                    {
                        if (value1 < value2)
                        {
                            TemperatureData temp = TemperatureData.temperatureDataArray[j];
                            TemperatureData.temperatureDataArray[j] = TemperatureData.temperatureDataArray[j + 1];
                            TemperatureData.temperatureDataArray[j + 1] = temp;
                        }
                    }


                }
            }
            Console.Clear();
            PrintArray(TemperatureData.temperatureDataArray);
            TemperatureData.temperatureDataArray = tempArray;
        }
        public static void FindWarmDays()
        {
            //A list is used to store all the warm days instead of an array
            //since we cannot know how many warm days there will be therefore
            //our storage needs to be able to expand to fit the need. 
            List<TemperatureData> WarmTemperatureList = new List<TemperatureData>();
            int userInput = 0;
            bool menu = true;
            while (menu)
            {
                Console.Write("\tEnter a temperature greater than 0! We will show you ever day that is warmer than your choice:");
                Int32.TryParse(Console.ReadLine(), out userInput);
                //Confirms if the TryParse work, since a failed Parse would return 0.
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

            for (int i = 0; i < TemperatureData.temperatureDataArray.Length; i++)
            {   
                //Adds the TemperatureData to the list if is value is greater then
                //what the user inputed. 
                if (userInput <= TemperatureData.temperatureDataArray[i].Temperature)
                {
                    WarmTemperatureList.Add(TemperatureData.temperatureDataArray[i]);
                }

            }
            TemperatureData[] tempArray = new TemperatureData[WarmTemperatureList.Count];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = WarmTemperatureList[i];
            }
            Console.WriteLine($"\tThese were the days where it was {userInput}°C or warmer:\n\n");
            PrintArray(tempArray);
        }
        public static void FindSpecificDay()
        {
            //We know we only need to store 3 values so we can use a
            //instanced array with a size of 3.
            TemperatureData[] temp = new TemperatureData[3];
            int userInput = 0;
            bool menu = true;
            while (menu)
            {
                Console.Write($"\tEnter a date between 1 - {TemperatureData.temperatureDataArray.Length} and we will " +
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
            for (int i = 0; i < TemperatureData.temperatureDataArray.Length; i++)
            {
                if (userInput == TemperatureData.temperatureDataArray[i].Days)
                {
                    //Checks if the value is 1 and removes the -1 index
                    // since that would put us out side the index range.
                    if (userInput == 1)
                    {
                        temp = new TemperatureData[2];
                        temp[0] = TemperatureData.temperatureDataArray[i];
                        temp[1] = TemperatureData.temperatureDataArray[i + 1];
                    }
                    //Checks if the value is the length of our array and removes the +1
                    //index since that would put us out side the index range.
                    else if (userInput == TemperatureData.temperatureDataArray.Length)
                    {
                        temp = new TemperatureData[2];
                        temp[0] = TemperatureData.temperatureDataArray[i - 1];
                        temp[1] = TemperatureData.temperatureDataArray[i];
                    }
                    else
                    {
                        temp[0] = TemperatureData.temperatureDataArray[i - 1];
                        temp[1] = TemperatureData.temperatureDataArray[i];
                        temp[2] = TemperatureData.temperatureDataArray[i + 1];
                    }

                }
            }
            Console.WriteLine($"\tHere is {userInput} of May and its neighbouring days\n");
            PrintArray(temp);
        }
        public static void FindMostCommonTemperature()
        {

            int commonTemperatureCount = 0;
            int commonTemperatureValue = 0;
            for (int i = 0; i < TemperatureData.temperatureDataArray.Length; i++)
            {
                // The outer loop selects one temperature at a time to loop
                // through the inner loop.
                int currentTemp = TemperatureData.temperatureDataArray[i].Temperature;
                int currentTempCount = 0;
                //Takes the previously selected value and compares it against every
                //other value and increases the count for each time it matches.
                for (int j = 0; j < TemperatureData.temperatureDataArray.Length; j++)
                {
                    if (currentTemp == TemperatureData.temperatureDataArray[j].Temperature)
                    {
                        currentTempCount++;
                    }
                }
                //Checks if the looped temperature is the most common one and puts it
                // in the veriabl if its true.
                if (currentTempCount > commonTemperatureCount)
                {
                    commonTemperatureCount = currentTempCount;
                    commonTemperatureValue = TemperatureData.temperatureDataArray[i].Temperature;

                }
            }
            Console.Clear();
            Console.WriteLine($"\tThe most common temperature was: {commonTemperatureValue}°C and it appeared {commonTemperatureCount} times\n");
        }
        public static void FindMedian()
        {
            TemperatureData[] tempArray = TemperatureData.temperatureDataArray;
            //Finding the median requires the list to be sorted
            SortArray();
            //We can find the median by dividing by two since we know the lenght of 
            //the array will always be a odd number.
            int medianPoint = TemperatureData.temperatureDataArray.Length / 2;
            int medianValue = temperatureDataArray[medianPoint].Temperature;
            Console.WriteLine($"\tThe median temperature of May is {medianValue}\n");
        }

    }
}


