using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Lab3
{



    public class Program
    {
       public static void Main(string[] args)
        {

            TemperatureInformation temperature = new TemperatureInformation("May", 31);
            TemperatureData[] temperatureDataArray = temperature.GenerateRandomTemperaturesInMonth(31);
            temperature.PrintArray(temperatureDataArray);
            temperature.AverageTemperature(temperatureDataArray);
            temperature.HighestTemperature(temperatureDataArray);
            temperature.LowestTemperature(temperatureDataArray);
            temperature.BubbleSort(temperatureDataArray, 1);
            temperature.PrintArray(temperatureDataArray);
            temperature.WarmDays(10,temperatureDataArray);
            temperature.SpecificDays(10, temperatureDataArray);
            temperature.MostCommonTemperature(temperatureDataArray);
            Console.ReadLine();
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
        public void HighestTemperature(TemperatureData[] temperatureArray)
        {
            int highestValue = 0;
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (temperatureArray[i].Temperature > highestValue)
                {
                    highestValue = temperatureArray[i].Temperature;
                }
            }
            Console.WriteLine($"Highest temperature in {Month}: {highestValue}°C");
        }
        public void LowestTemperature(TemperatureData[] temperatureArray)
        {
            int lowestValue = temperatureArray[0].Temperature;
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                if (temperatureArray[i].Temperature < lowestValue)
                {
                    lowestValue = temperatureArray[i].Temperature;
                }
            }
            Console.WriteLine($"Lowest temperature in {base.Month}: {lowestValue}°C");
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
}
