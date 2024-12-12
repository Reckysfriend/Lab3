using System.Reflection.Metadata.Ecma335;

namespace Lab3
{

    /*
     * A way to sort the temperature both ascending and descending.
     * A way to only show days above X temperature to identifiy warmer days.
     * Ability to enter a date and return the temperature of that day and its neighbouring days.
     * A way to get the most common temperature in May.
     */


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
            temperature.BubbleSort(temperatureDataArray);
            temperature.PrintArray(temperatureDataArray);
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
        public void BubbleSort(TemperatureData[] temperatureArray)
        {
            int max = temperatureArray.Length - 1;
            for (int i = 0; i < max; i++)
            {
                int left = max - i;
                for (int j = 0; j < left; j++)
                {
                    int value1 = temperatureArray[j].Temperature;
                    int value2 = temperatureArray[j + 1].Temperature;
                    if (value1 > value2)
                    {
                        TemperatureData temp = temperatureArray[j];
                        temperatureArray[j] = temperatureArray[j + 1];
                        temperatureArray[j + 1] = temp;
                    }
                }
            }

        }
    }
}
