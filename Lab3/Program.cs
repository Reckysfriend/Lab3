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

            TemperatureInformation temperature = new TemperatureInformation(31, "May");
            List<TemperatureData> temperatureDataList = temperature.GenerateRandomTemperaturesInMonth(temperature.Days,temperature.Month);
            temperature.PrintArray(temperatureDataList);
            temperature.AverageTemperature(temperatureDataList);
            temperature.HighestTemperature(temperatureDataList);
            temperature.LowestTemperature(temperatureDataList);
            temperature.BubbleSort(temperatureDataList);
            temperature.PrintArray(temperatureDataList);
            Console.ReadLine();
        }
    }
    class TemperatureData
    {
        public string Month { get; private set; }
        public int Days { get; private set; }
        public int Temperature { get; private set; }

        public TemperatureData(int days, string month)
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
        public List<TemperatureData> GenerateRandomTemperaturesInMonth(int days, string month)
        {
            List<TemperatureData> list = new List<TemperatureData>();
            Random rnd = new Random();

            int x = 1;
            for (int i = 0; i < days; i++)
            {
                TemperatureData tempData = new TemperatureData();
                tempData.Days = x++;
                tempData.Month = month;
                tempData.Temperature = rnd.Next(0, 25 + 1);
                list.Add(tempData);

            }
            return list;
        }

    }
    class TemperatureInformation : TemperatureData
    {
        public TemperatureInformation(int days, string month) : base(days, month) { }

        public void AverageTemperature(List<TemperatureData> temperatureDatas)
        {
            int sumOfArray = 0;
            for (int i = 0; i < temperatureDatas.Count; i++)
            {
                sumOfArray += temperatureDatas[i].Temperature;
            }

            int averageSumOfArray = sumOfArray / temperatureDatas.Count;
            Console.WriteLine($"The average temperature in {Month}: {averageSumOfArray}°C");
        }
        public void HighestTemperature(List<TemperatureData> temperatureDatas)
        {
            int highestValue = 0;
            for (int i = 0; i < temperatureDatas.Count; i++)
            {
                if (temperatureDatas[i].Temperature > highestValue)
                {
                    highestValue = temperatureDatas[i].Temperature;
                }
            }
            {
                
            }
            Console.WriteLine($"Highest temperature in {Month}: {highestValue}°C");
        }
        public void LowestTemperature(List<TemperatureData> temperatureDatas)
        {
            int lowestValue = temperatureDatas[0].Temperature;
            for (int i = 0; i < temperatureDatas.Count; i++)
            {
                if (temperatureDatas[i].Temperature < lowestValue)
                    {
                        lowestValue = temperatureDatas[i].Temperature;
                    }               
            }
   
            Console.WriteLine($"Lowest temperature in {base.Month}: {lowestValue}°C");
        }
        public void PrintArray(List<TemperatureData> temperatureDatas)
        {
            for (int i = 0; i < temperatureDatas.Count; i++)
            {
               Console.WriteLine($"{temperatureDatas[i].Month} {temperatureDatas[i].Days}: {temperatureDatas[i].Temperature}°C");
            }
        }
        public void BubbleSort(List<TemperatureData> temperatureDatas)
        {
            int max = temperatureDatas.Count - 1;
            for (int i = 0; i < max; i++)
            {
                int left = max - i;
                for (int j = 0; j < left; j++)
                {
                    int value1 = temperatureDatas[j].Temperature;
                    int value2 = temperatureDatas[j + 1].Temperature;
                        if (value1 > value2)
                    {
                        TemperatureData temp = temperatureDatas[j];
                        temperatureDatas[j] = temperatureDatas[j + 1];
                        temperatureDatas[j + 1] = temp;
                    }
                }
            }
                
        }

    }

}
