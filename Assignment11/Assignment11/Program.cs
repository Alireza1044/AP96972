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

        public static TitanicData OldestPerson(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(p => p.Age).First();

        public static TitanicData OldestFemale(this IEnumerable<TitanicData> data)
            => data.Where(p => p.IsFemale).OrderByDescending(p => p.Age).First();

        public static int TotalPassengers(this IEnumerable<TitanicData> data)
            => data.Count();

        public static int TotalFemales(this IEnumerable<TitanicData> data)
            => data.Where(p => p.IsFemale).Count();

        public static int TotalSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Survived).Count();

        public static double SurvivorsPercentage(this IEnumerable<TitanicData> data)
            => (double)data.Where(p => p.Survived).Count() * 100 / data.Count();

        public static int FemaleSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Survived && p.IsFemale).Count();

        public static double FemaleSurvivorsPercentage(this IEnumerable<TitanicData> data)
           => (double)data.Where(p => p.Survived && p.IsFemale).Count() * 100 / data.TotalFemales();

        public static double SurvivorsIsFemalePercentage(this IEnumerable<TitanicData> data)
            => (double)data.Where(p => p.Survived && p.IsFemale).Count() * 100 / data.Where(p => p.Survived).Count();

        public static double KidsUnder10Survived(this IEnumerable<TitanicData> data)
            => (double)data.Where(p => (p.Age < 10) && p.Survived).Count() * 100 / data.Where(p => (p.Age < 10)).Count();

        public static string PortsWithMostSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Survived).GroupBy(p => p.BoardingPort).OrderByDescending(p => p.Count()).First().Key;

        public static string PortsWithMostSurvivorsPercentage(this IEnumerable<TitanicData> data)
        => data.GroupBy(p => p.BoardingPort).Where(p => p.Key != "").Select(x => new
        {
            PassengerCount = (double) x.Where(p => p.Survived).Count() / x.Count(),
            PortName = x.Key,
        }).OrderByDescending(p => p.PassengerCount).First().PortName;

        public static string MostAgeGroupPassengers(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Age != null).GroupBy(p => p.Age / 10).Select(x => new
            {
                PassengersCount = x.Count(),
                GroupAgeRange = $"{(int)x.Key * 10 } to {(int)x.Key * 10 + 9}"
            }).OrderByDescending(p => p.PassengersCount).First().GroupAgeRange;

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
