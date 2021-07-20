using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS205_07192021_Bulls_and_Cows
{
    class Program
    {
        static void Main(string[] args)
        {
            //Here's happening how programm asks user to input the range/difficulty of the code
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "\n ******   **     ** **       **        ********     **        ******    *******   **       **  ********" +
                "\n/*////** /**    /**/**      /**       **//////     */ *      **////**  **/////** /**      /** **////// " +
                "\n/*   /** /**    /**/**      /**      /**          / **      **    //  **     //**/**   *  /**/**       " +
                "\n/******  /**    /**/**      /**      /*********    */ * *  /**       /**      /**/**  *** /**/*********" +
                "\n/*//// **/**    /**/**      /**      ////////**   *  / *   /**       /**      /**/** **/**/**////////**" +
                "\n/*    /**/**    /**/**      /**             /**  /*   /*   //**    **//**     ** /**** //****       /**" +
                "\n/******* //******* /********/******** ********   / **** *   //******  //*******  /**/   ///** ******** " +
                "\n///////   ///////  //////// //////// ////////     //// /     //////    ///////   //       // ////////  \n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter number from 3 to 5");
            int dif_Level = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out dif_Level))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if ((dif_Level < 3) || (dif_Level > 5))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid range. Try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                break;
            }
            //Here code creates randomized code for the player
            var random = new Random();
            List<int> b_c_Array = new List<int>();
            int number;
            for(int i = 0; i < dif_Level; i++)
            {
                do
                {
                    number = random.Next(0, 10);
                } while (b_c_Array.Contains(number));
                b_c_Array.Add(number);
                //Console.WriteLine(string.Join(",", b_c_Array));
            }
            Console.WriteLine("Guess your number\nEnter '" + dif_Level + "' numbers from 0 to 9");
            List<int> answer = new List<int>();
            //uses newly created class especially for this porpose only for creating new answer and checking for errors in input
            answer = new Check(b_c_Array).Init();
            //Loop for entering answer and checking for errors
            while (true) {
                int cows = 0;
                int bulls = 0;
                if (Enumerable.SequenceEqual(b_c_Array, answer))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations !\nYou did it right !\nNumber was:" + string.Join(",", b_c_Array));
                    Console.ReadLine();
                    break;
                }
                else
                {
                    //Checks for how many cows and bulls answer has
                    for(int x = 0; x < dif_Level; x++)
                    {
                        for(int y = 0;y < dif_Level; y++)
                        {
                            if (answer[x] == b_c_Array[y] && x == y)
                            {
                                cows++;
                            }else if (answer[x] == b_c_Array[y])
                            {
                                bulls++;
                            }
                        }
                    }
                    Console.WriteLine("Guess again...\nCows: "+bulls+"\nBulls:"+ cows + "\nEnter '" + dif_Level + "' numbers from 0 to 9");
                    //uses newly created class especially for this porpose only for creating new answer and checking for errors in input
                    answer = new Check(b_c_Array).Init();
                }
            }
        }
    }
}
