using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS205_07192021_Bulls_and_Cows
{
    class Check
    {
        List<int> b_c_List;
        //constructor for class
        public Check(List<int> b_c_List)
        {
            this.b_c_List = b_c_List;
        }
        //method for creating the entered numbers for any issues and then returning the List with the answer numbers 
        public List<int> Init()
        {
            List<int> answer = new List<int>();
            for (int i = 0; i < b_c_List.Count; i++)
            {
                int tempNum = 0;
                while (true)
                {
                    
                    if (!int.TryParse(Console.ReadLine(), out tempNum))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Try again");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((tempNum < 0) || (tempNum > 9))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid range. Try again");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (answer.Contains(tempNum))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("this number was already entered. Try again");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        answer.Add(tempNum);
                        break;
                    }
                }
            }
            return answer;
        }
    }
}
