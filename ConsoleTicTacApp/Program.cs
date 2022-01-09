using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleTicTacApp
{
    class Program
    {

        //making array and  
        //by default I am providing 0-9 where no use of zero
        
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //By default player 1 is set
        static int choice; //This holds the choice at which position user want to mark.

        //The flag variable checks who won if it's value = 1, somebody won 
        // value = -1, draw and if value = 0 the match is still running.

        static int flag = 0;

        static void Main(string[] args)
        {

            do
            {
                Console.Clear(); // whenever loop will be again start then screen will 
                
                Console.WriteLine("Player1:X and Player2:0");

                Console.WriteLine("\n");
                if (player % 2 == 0)  //checking the chance of the player
                                      // %: is used for remainder. Also known as modulo operator.
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }

                Console.WriteLine("\n");
                Board(); // calling the board function
                choice = int.Parse(Console.ReadLine()); // Tracking User Choice

                // checking that position where user want to run is marked (with X or 
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)  // if chance is of player 2 then mark O else mark X
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                //If there is any position where user want to run
                //and that is already marked then show message and load board again

                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again......");
                    Thread.Sleep(2000);
                }

                flag = CheckWin(); // calling of check win
            }

            while(flag != 1 && flag != -1);

                // This loop will be run until all cell of the grid is not marked 
                // with X and O or some player is not win

                Console.Clear(); // clearing the console
                Board(); // getting filled board again

                if (flag == 1)
            // if flag value is 1 then someone has win or 
            // means who played marked last time which has win
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
                else // if flag value is -1 the match will be draw and no one is winner
            {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();

        }

        // Board Method which creates board
        private static void Board()
        {

            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  | {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  | {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  | {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |     ");
        }

        // Checking whether any player has won or not
        private static int CheckWin()
        {

            #region Horizontal Winning Condition

            // Winning Condition For First Row

            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }

            //Winning Condition for Second Row

            else if (arr[4] == arr[5] && arr[5] == arr[6])
                {
                    return 1;
                }

            //Winning Condition for Third Row 

            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }

            #endregion;

            #region Vertical Winning Condition

            // Winning Condition For First Col

            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }

            //Winning Condition for Second Col

            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }

            //Winning Condition for Third Col

            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            #endregion;

            #region Diagonal Winning Condition

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }

            //Winning Condition for Second Col

            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            #endregion;

            #region checking for draw

            // if all the cells or values filled with X or O then any player has won the match

            // now this is important to continue the match other wise there was no need to write else if 

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4')
            {
                return -1;
            }

            #endregion;

            else
            {
                return 0;
            }

        }

    }
}
