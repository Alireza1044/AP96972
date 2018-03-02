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
        /// and then the "ProbabilityCounterFunc" function counts the probability and returns it
        /// Writes the result in the terminal
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int SelectedNumberforProbability;
            int[] EnteredNumsByUser = new int[8];
            for (int i = 0; i < 8; i++) // reads the entered numbers from user
            {
                EnteredNumsByUser[i] = int.Parse(Console.ReadLine()); //array of the entered numbers
            }
            SelectedNumberforProbability = int.Parse(Console.ReadLine());
            while (SelectedNumberforProbability != -1) //counts the probability while the entered number is not -1
            {
                Console.WriteLine(ProbabilityCounterFunc(SelectedNumberforProbability, EnteredNumsByUser));
                SelectedNumberforProbability = int.Parse(Console.ReadLine());
            }
        }
        /// <summary>
        /// counts the probability of the entered number in the list
        /// </summary>
        /// <param name="SelectedNumberforProbability"> selected number by user to count the probability </param>
        /// <param name="EnteredNumsByUser"> numbers entered by user in the array  </param>
        /// <returns> the probability of the chosen number </returns>
        public static float ProbabilityCounterFunc(int SelectedNumberforProbability, int[] EnteredNumsByUser)
        {
            float Result; // probability
            float Counter = 0; // repeatative numbers
            for (int i = 0; i < 8; i++) // counts the repeatative numbers
            {
                if (SelectedNumberforProbability == EnteredNumsByUser[i])
                {
                    Counter++;
                }
            }
            Result = Counter / 8; // counts the probability
            return Result;
        }
    }
}