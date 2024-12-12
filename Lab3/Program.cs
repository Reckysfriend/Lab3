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
            temperature.printarray(temperatureDataArray);
            temperature.averagetemperature(temperatureDataArray);
            temperature.highesttemperature(temperatureDataArray);
            temperature.lowesttemperature(temperatureDataArray);
            temperature.bubblesort(temperatureDataArray);
            temperature.printarray(temperatureDataArray);
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
            foreach (int x in temperatureArray)
            {
                sumOfArray += x;
            }
            int averageSumOfArray = sumOfArray / temperaturesInMonth.Length;
            Console.WriteLine($"The average temperature in {Month}: {averageSumOfArray}°C");
        }
        public void HighestTemperature()
        {
            int highestValue = 0;
            foreach (int x in temperaturesInMonth)
            {
                if (x > highestValue)
                {
                    highestValue = x;
                }
            }
            Console.WriteLine($"Highest temperature in {Month}: {highestValue}°C");
        }
        public void LowestTemperature(TemperatureData[] temperatureArray)
        {
            int lowestValue = temperaturesInMonth[0];
            foreach (int x in temperaturesInMonth)
            {
                if (x < lowestValue)
                {
                    lowestValue = x;
                }
            }
            Console.WriteLine($"Lowest temperature in {base.Month}: {lowestValue}°C");
        }
        public void PrintArray(TemperatureData[] temperatureArray)
        {
            int y = 0;
            foreach (int x in temperaturesInMonth)
            {
                y++;
                Console.WriteLine($"{Month} {y}: {x}°C");
            }
        }
        public void BubbleSort(TemperatureData[] temperatureArray)
        {
            int max = temperaturesInMonth.Length - 1;
            for (int i = 0; i < max; i++)
            {
                int left = max - i;
                for (int j = 0; j < left; j++)
                {
                    int value1 = temperaturesInMonth[j];
                    int value2 = temperaturesInMonth[j + 1];
                    if (value1 > value2)
                    {
                        int temp = temperaturesInMonth[j];
                        temperaturesInMonth[j] = temperaturesInMonth[j + 1];
                        temperaturesInMonth[j + 1] = temp;
                    }
                }
            }

        }

    }

}
