using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Program
    {
        /// <summary>
        /// first reads the numbers enrtered by user and stores them in an array
        /// then reads the number
        /// and then the "Entrance" function counts the probability and returns it
        /// Writes the result in the terminal
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int SelectedNumber;
            float Counter = 0;
            int[] Numbers = new int[8];
            for (int i = 0; i < 8; i++) // reads the entered numbers from user
            {
                Numbers[i] = int.Parse(Console.ReadLine()); //array of the entered numbers
            }
            SelectedNumber = int.Parse(Console.ReadLine());
            while (SelectedNumber != -1) //counts the probability while the entered number is not -1
            {
                Console.WriteLine(Entrance(SelectedNumber, Counter, Numbers));
                SelectedNumber = int.Parse(Console.ReadLine());
            }
        }
        /// <summary>
        /// counts the probability of the entered number in the list
        /// </summary>
        /// <param name="ArrNumbers"> numbers in the array </param>
        /// <param name="Counter"> repeatative numbers in the entered numbers </param>
        /// <param name="Numbers"> entered numbers by user </param>
        /// <returns> the probability of the chosen number </returns>
        public static float Entrance(int ArrNumbers, float Counter, int[] Numbers)
        {
            float Result; // probability
            Counter = 0;
            for (int i = 0; i < 8; i++) // counts the repeatative numbers
            {
                if (ArrNumbers == Numbers[i])
                {
                    Counter++;
                }
            }
            Result = Counter / 8; // counts the probability
            return Result;
        }
    }
}