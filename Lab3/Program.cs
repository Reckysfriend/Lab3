using System.Reflection.Metadata.Ecma335;

namespace Lab3
{
/*
 * Static Array with all dates of May
 * A class for temperature
 * A way to display all the temperature of all days in May
 * A way to display the average emperature in May based on array.
 * A way to find the hottest day in May and display it.
 * A way to find the coldest day in May and display it.
 * A way to find the median temperature of May and display it.
 * A way to sort the temperature both ascending and descending.
 * A way to only show days above X temperature to identifiy warmer days.
 * Ability to enter a date and return the temperature of that day and its neighbouring days.
 * A way to get the most common temperature in May.
 * Fill the May-array with random elements via Random
 */
    public class Program
    {
       public static void Main(string[] args)
        {
            Temperature temperature = new Temperature();
            Console.Write("Please enter any amount of days:");
            Int32.TryParse(Console.ReadLine(), out int userInput);
            int[] temperatureArray = temperature.RandomTemperaturesInMonth(userInput);
            temperature.PrintArray(temperatureArray, "May");
            Console.WriteLine(" ");
            temperature.AverageTemperature(temperatureArray);
            Console.ReadLine();

        }
    }
    public class Temperature
    {
        public int[] RandomTemperaturesInMonth(int days)
        {
            int[] temperatureArray = new int[days];
            Random random = new Random();
            for (int i = 0; i < temperatureArray.Length; i++)
            {
                int x = random.Next(0, 25 + 1);
                temperatureArray[i] = x;
            }
            return temperatureArray;
        }
         public void PrintArray(int[] intArray , string month)
        {
            int y = 0;
            foreach (int x in intArray)
            {
                y++;
                Console.WriteLine($"{month} {y}: {x}°C");
            }
        }
        public void AverageTemperature(int[] intArray)
        {
            int sumOfArray = 0;
            foreach (int x in intArray)
            {
                sumOfArray += x;
            }
            int averageSumOfArray = sumOfArray / intArray.Length;
            Console.WriteLine($"The average temperature of the month is {averageSumOfArray}!");
        }
    }
}
