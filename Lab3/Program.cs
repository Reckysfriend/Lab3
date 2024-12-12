using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

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
                            Console.WriteLine("Average Temp");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Apex Temp");
                            break;
                        }
                    case 3:
                        {
                                Console.WriteLine("Warmest");
                                break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Sort");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Search by day");
                            break;
                        }
                    case 6: {
                            Console.WriteLine("Common temp");
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





            //temperature.AverageTemperature(temperatureDataArray);
            //temperature.ApexTemperatures(temperatureDataArray, 1);
            //temperature.BubbleSort(temperatureDataArray, 1);
            //temperature.WarmDays(10,temperatureDataArray);
            //temperature.SpecificDays(10, temperatureDataArray);
            //temperature.MostCommonTemperature(temperatureDataArray);
            //Console.ReadLine();
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
            Console.WriteLine($"The average temperature in {Month}: {averageSumOfArray}°C");
        }
        public void ApexTemperatures(TemperatureData[] temperatureArray, int userInput)
        {
            int minMax = temperatureArray[0].Temperature;
            string minMaxstr = "";
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (userInput == 0)
                {
                    if (temperatureArray[i].Temperature > minMax)
                    {
                        minMax = temperatureArray[i].Temperature;
                        minMaxstr = "Highest";
                    }
                 }
                else
                {
                    if (temperatureArray[i].Temperature < minMax)
                    {
                        minMax = temperatureArray[i].Temperature;
                        minMaxstr = "Lowest";
                    }

                }

            }
            Console.WriteLine($"{minMaxstr} temperature in {Month}: {minMax}°C");
        }
        public void PrintArray(TemperatureData[] temperatureArray)
        {
            int y = 0;
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                y++;
                Console.WriteLine($"{Month} {temperatureArray[i].Days} - {temperatureArray[i].Temperature}°C");
            }
        }
        public void BubbleSort(TemperatureData[] temperatureArray, int userinput)
        {
            int max = temperatureArray.Length - 1;
            for (int i = 0; i < max; i++)
            {
                int left = max - i;
                for (int j = 0; j < left; j++)
                {
                    int value1 = temperatureArray[j].Temperature;
                    int value2 = temperatureArray[j + 1].Temperature;
                    if (userinput == 0)
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

        }
        public void WarmDays (int userinput, TemperatureData[] temperatureArray)
        {
            List<TemperatureData> WarmTemperatureList = new List<TemperatureData>();
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (userinput <= temperatureArray[i].Temperature)
                {
                    WarmTemperatureList.Add(temperatureArray[i]);
                }

            }
            TemperatureData[] tempArray = new TemperatureData[WarmTemperatureList.Count];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = WarmTemperatureList[i];
            }
            PrintArray(tempArray);
        }
        public void SpecificDays (int userinput, TemperatureData[] temperatureArray)
        {
            TemperatureData[] temp = new TemperatureData[3];
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (userinput == temperatureArray[i].Days)
                {
                    
                    temp[0] = temperatureArray[i - 1];
                    temp[1] = temperatureArray[i];
                    temp[2] = temperatureArray[i + 1];
                }
            }
            Console.WriteLine("Print Specific Day:\n"); 
            PrintArray (temp);
        }
        public void MostCommonTemperature(TemperatureData[] temperatureArray)
        {
            int highestTemperature = 0;
            int highestTemperatureValue = 0;
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                int currentTemp = temperatureArray[i].Temperature;
                int currentTempCount = 0;
                for (int j = 0; j < temperatureArray.Length; j++)
                {
                    if(currentTemp == temperatureArray[j].Temperature)
                    {
                        currentTempCount++;
                    }
                }
                if(currentTempCount > highestTemperature)
                {
                    highestTemperature = currentTempCount;
                    highestTemperatureValue = temperatureArray[i].Temperature;
                    
                }
            }
            Console.WriteLine($"Higest temp was: {highestTemperatureValue} and appeared {highestTemperature} times");
        }
    }
