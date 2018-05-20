using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"Titanic.csv")
                .Skip(1)
                .Select(line => new TitanicData(line));

            Console.WriteLine($"Paid the highest fare: {data.GetMostExpensiveFare().Name}");
            
            // If necessary, you can use more than one extension method to calculate these answers.
            Console.WriteLine($"Oldest person's name: {data.OldestPerson().Name}");
            Console.WriteLine($"Oldest female's name: {data.OldestFemale().Name}");
            Console.WriteLine($"Total passengers: {data.TotalPassengers()}");
            Console.WriteLine($"Total Female passengers: {data.TotalFemales()}");
            Console.WriteLine($"Total number of survivors: {data.TotalSurvivors()}");
            Console.WriteLine($"Percent of passengers who survived: {data.SurvivorsPercentage()}");
            Console.WriteLine($"Number of female Survivors: {data.FemaleSurvivors()}");
            Console.WriteLine($"Percent of females who survived: {data.FemaleSurvivorsPercentage()}");
            Console.WriteLine($"Percent of survivors who were female: {data.SurvivorsIsFemalePercentage()}");
            Console.WriteLine($"Percent of kids under 10 who survived: {data.KidsUnder10Survived()}");
            Console.WriteLine($"Port of boarding with most survivors: {data.PortsWithMostSurvivors()}");
            Console.WriteLine($"Port of boarding with most survivors percent: {data.PortsWithMostSurvivorsPercentage()}");
            Console.WriteLine($"The age group (age/10) with most passengers: {data.MostAgeGroupPassengers()}");
            Console.WriteLine($"The age group (age/10) with most survivors: {data.MostAgeGroupSurvivors()}");
            Console.ReadKey();
        }
    }


    public static class Extensions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        public static Nullable<double> ParseDoubleOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? double.Parse(str) as Nullable<double> : null;

        public static TitanicData GetMostExpensiveFare(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Fare).First();


        /// <summary>
        /// you must modify the name of this method and its 
        /// implementation to fit your need and create more methods like this
        public static TitanicData ExtensionMethodPlaceHolder(this IEnumerable<TitanicData> data)
            => data.First();

        /// <summary>
        /// finds the oldest person on the ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns> sorts the data by age descending and returns the first one </returns>
        public static TitanicData OldestPerson(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(p => p.Age).First();

        /// <summary>
        /// finds the oldest female on the ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns> filters the data by gender and then sorts them by age and returns the first one </returns>
        public static TitanicData OldestFemale(this IEnumerable<TitanicData> data)
            => data.Where(p => p.IsFemale).OrderByDescending(p => p.Age).First();

        /// <summary>
        /// counts the total passengers on the ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns> total passengers count </returns>
        public static int TotalPassengers(this IEnumerable<TitanicData> data)
            => data.Count();

        /// <summary>
        /// counts the total number of females on the ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns> total number of females </returns>
        public static int TotalFemales(this IEnumerable<TitanicData> data)
            => data.Where(p => p.IsFemale).Count();

        /// <summary>
        /// counts the total number of survivors
        /// </summary>
        /// <param name="data"></param>
        /// <returns> total number of survivors </returns>
        public static int TotalSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Survived).Count();

        /// <summary>
        /// counts the percentage of survivors to total number of passengers
        /// </summary>
        /// <param name="data"></param>
        /// <returns> survivors percentage </returns>
        public static double SurvivorsPercentage(this IEnumerable<TitanicData> data)
            => (double)data.Where(p => p.Survived).Count() * 100 / data.Count();

        /// <summary>
        /// counts the total number of females who have survived
        /// </summary>
        /// <param name="data"></param>
        /// <returns> total survived females </returns>
        public static int FemaleSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Survived && p.IsFemale).Count();

        /// <summary>
        /// counts the percentage of females who survived to total number of females
        /// </summary>
        /// <param name="data"></param>
        /// <returns> percentage of survived females to all females </returns>
        public static double FemaleSurvivorsPercentage(this IEnumerable<TitanicData> data)
           => (double)data.Where(p => p.Survived && p.IsFemale).Count() * 100 / data.TotalFemales();

        /// <summary>
        /// counts the percentage of total survived females to total survived passengers
        /// </summary>
        /// <param name="data"></param>
        /// <returns> percentage of survived females to all survived passengers </returns>
        public static double SurvivorsIsFemalePercentage(this IEnumerable<TitanicData> data)
            => (double)data.Where(p => p.Survived && p.IsFemale).Count() * 100 / data.Where(p => p.Survived).Count();

        /// <summary>
        /// counts the percentage of total kids under 10 who have survived to all the kids under 10
        /// </summary>
        /// <param name="data"></param>
        /// <returns> percentage of suvived kids under 10 </returns>
        public static double KidsUnder10Survived(this IEnumerable<TitanicData> data)
            => (double)data.Where(p => (p.Age < 10) && p.Survived).Count() * 100 / data.Where(p => (p.Age < 10)).Count();

        /// <summary>
        /// groups the passengers by survival status and the port they have boarded the ship
        /// then sorts 
        /// </summary>
        /// <param name="data"></param>
        /// <returns> the port with most survived passengers </returns>
        public static string PortsWithMostSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Survived).GroupBy(p => p.BoardingPort).OrderByDescending(p => p.Count()).First().Key;

        /// <summary>
        /// groups the passengers by the ports they have boarded the ship
        /// then creates an anonymous class and counts the percentage of survived passengers in each port
        /// </summary>
        /// <param name="data"></param>
        /// <returns> the port with most survived passengers percentage </returns>
        public static string PortsWithMostSurvivorsPercentage(this IEnumerable<TitanicData> data)
        => data.GroupBy(p => p.BoardingPort).Where(p => p.Key != "").Select(x => new
        {
            PassengerCount = (double) x.Where(p => p.Survived).Count() / x.Count(),
            PortName = x.Key,
        }).OrderByDescending(p => p.PassengerCount).First().PortName;
        
        /// <summary>
        /// groups the passengers by age/10 and counts the total passengers of each age group
        /// </summary>
        /// <param name="data"></param>
        /// <returns> the age group with most passengers </returns>
        public static string MostAgeGroupPassengers(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Age != null).GroupBy(p => p.Age / 10).Select(x => new
            {
                PassengersCount = x.Count(),
                GroupAgeRange = $"{(int)x.Key * 10 } to {(int)x.Key * 10 + 9}"
            }).OrderByDescending(p => p.PassengersCount).First().GroupAgeRange;

        /// <summary>
        /// groups the passengers by age/10 and counts the total survivors of each age group
        /// </summary>
        /// <param name="data"></param>
        /// <returns> the age group with most survivors </returns>
        public static string MostAgeGroupSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Age != null).GroupBy(p => p.Age / 10).Select(x => new
            {
                SurvivorsCount = x.Where(p => p.Survived).Count(),
                GroupAgeRange = $"{(int)x.Key * 10 } to {(int)x.Key * 10 + 9}"
            }).OrderByDescending(p => p.SurvivorsCount).First().GroupAgeRange;
    }

    public class TitanicData
    {
        public TitanicData(string line)
        {
            var toks = line.Split(',');
            PassengerId = toks[0];
            Survived = toks[1] == "1";
            PClass = toks[2];
            Name = toks[3];
            IsFemale = toks[4] == "female";
            Age = toks[5].ParseDoubleOrNull();
            SibilingsOnBoard = toks[6].ParseIntOrNull();
            ParentsOnBoard = toks[7].ParseIntOrNull();
            Ticket = toks[8];
            Fare = double.Parse(toks[9]);
            Cabin = toks[10];
            BoardingPort = toks[11];
        }
        public string PassengerId;
        public bool Survived;
        public string PClass;
        public string Name;
        public bool IsFemale;
        public Nullable<double> Age;
        public Nullable<int> SibilingsOnBoard;
        public Nullable<int> ParentsOnBoard;
        public string Ticket;
        public double Fare;
        public string Cabin;
        public string BoardingPort;
    }
}
