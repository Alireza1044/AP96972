using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            int SelectedNumberForProbability;
            int[] intArrayOfEnteredNumsByUser = input(Console.In);
            do
            {
                SelectedNumberForProbability = int.Parse(Console.ReadLine());
                if (SelectedNumberForProbability == -1)
                    break;
                output(SelectedNumberForProbability, intArrayOfEnteredNumsByUser,Console.Out);
            } while (SelectedNumberForProbability != -1); //counts the probability while the entered number is not -1
        }
        /// <summary>
        /// reads the numbers in string and converts them to ints
        /// </summary>
        /// <returns></returns>
        public static int[] input(TextReader inStream)
        {
            string TempString;
            TempString = inStream.ReadLine(); //string of the entered numbers
            string[] stringArrayOfEnteredNumsByUser = TempString.Split();//seperetes the numbers seperated by ' ' and saves them in a string array
            int[] intArrayOfEnteredNumsByUser = new int[stringArrayOfEnteredNumsByUser.Length];
            for (int i = 0; i < stringArrayOfEnteredNumsByUser.Length; i++)//saves the numbers of "stringArrayOfEnteredNumsByUser" in an in int array
            {
                intArrayOfEnteredNumsByUser[i] = int.Parse(stringArrayOfEnteredNumsByUser[i]);
            }
            return intArrayOfEnteredNumsByUser;
        }
        /// <summary>
        /// prints the result
        /// </summary>
        /// <param name="SelectedNumberForProbability">selected number by user to count the probability</param>
        /// <param name="intArrayOfEnteredNumsByUser">numbers entered by user in the array</param>
        public static void output(int SelectedNumberForProbability,int[] intArrayOfEnteredNumsByUser ,TextWriter outStream)
        {
            outStream.WriteLine(ProbabilityCounterFunc(SelectedNumberForProbability, intArrayOfEnteredNumsByUser));
        }

        /// <summary>
        /// counts the probability of the entered number in the list
        /// </summary>
        /// <param name="SelectedNumberForProbability"> selected number by user to count the probability </param>
        /// <param name="intArrayOfEnteredNumsByUser"> numbers entered by user in the array  </param>
        /// <returns> the probability of the chosen number </returns>
        public static float ProbabilityCounterFunc(int SelectedNumberForProbability, int[] intArrayOfEnteredNumsByUser)
        {
            float Counter = 0; // repeatative numbers
            for (int i = 0; i < intArrayOfEnteredNumsByUser.Length; i++) // counts the repeatative numbers
            {
                if (SelectedNumberForProbability == intArrayOfEnteredNumsByUser[i])
                {
                    Counter++;
                }
            }
            return Counter / 8;
        }

    }
}