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
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] temperatureInMay = new int[31];
            Random random = new Random();
            int y = 0;

            for (int i = 0;  i < temperatureInMay.Length; i++)
            {
                int x = random.Next(0 , 25 + 1);
                temperatureInMay[i] = x;
            }
            foreach (int x in temperatureInMay)
            {
                y++;
                Console.WriteLine($"May {y}: {x}°C");
            }
        }
    }
}
