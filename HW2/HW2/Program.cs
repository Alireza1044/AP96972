using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int IntIn ;
            float Result , Counter = 0;
            int [] Numbers = new int[8];
            for (int i = 0; i < 8; i++) {
                Numbers[i] = int.Parse(Console.ReadLine());
            }
            IntIn = int.Parse(Console.ReadLine());
            while (IntIn != -1){
                Counter = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (IntIn == Numbers[i])
                    {
                        Counter++;
                    }
                }
                Result = Counter / 8;
                Console.WriteLine(Result);
                IntIn = int.Parse(Console.ReadLine());
            }
        }
    }
}