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
            temperature.PrintArray();
            temperature.AverageTemperature();
            temperature.HighestTemperature();
            temperature.LowestTemperature();
            temperature.BubbleSort();
            temperature.PrintArray();
            Console.ReadLine();
        }
    }
    class TemperatureData
    {
        public string Month { get; private set; }
        public int Days { get; private set; }
        protected int[] temperaturesInMonth;

        public TemperatureData(string month, int days)
        {
            Month = month;
            Days = days;
            temperaturesInMonth = new int[days];
            GenerateRandomTemperaturesInMonth();
        }
        public void GenerateRandomTemperaturesInMonth()
        {
            Random random = new Random();
            for (int i = 0; i < temperaturesInMonth.Length; i++)
            {
                int x = random.Next(0, 25 + 1);
                temperaturesInMonth[i] = x;
            }
        }

    }
    class TemperatureInformation : TemperatureData
    {
        public TemperatureInformation(string month, int days) : base(month, days) { }

        public void AverageTemperature()
        {
            int sumOfArray = 0;
            foreach (int x in temperaturesInMonth)
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
        public void LowestTemperature()
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
        public void PrintArray()
        {
            int y = 0;
            foreach (int x in temperaturesInMonth)
            {
                y++;
                Console.WriteLine($"{Month} {y}: {x}°C");
            }
        }
        public void BubbleSort()
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
