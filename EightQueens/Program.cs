using System;
using System.Collections.Generic;
using System.Linq;

namespace EightQueens
{
    class Program
    {
        static int[] arrangeNQueens(int n)
        {
            int[] Queens = new int[n];
            Random rand = new Random();
            Queens[0] = rand.Next(n);
            findPlaceForQueen(1, Queens);
            return Queens;
        }

        static bool findPlaceForQueen(int nextRange, int[] Queens)
        {
            int n = Queens.GetLength(0);
            List<int> availablePlaces = new List<int>();
            for (int k = 0; k < n; k++)
            {
                bool unthreatened = true;
                int j = 0;
                while (unthreatened && j < nextRange)
                {
                    if (k == Queens[j] || k + nextRange == Queens[j] + j || k - nextRange == Queens[j] - j) unthreatened = false;
                    j++;
                }
                if (unthreatened) availablePlaces.Add(k);

            }
            if (availablePlaces.Count() == 1 && nextRange == 7)
            {
                Queens[nextRange] = availablePlaces[0];
                return true;
            }
            else if (availablePlaces.Count() > 0)
            {
                for (int i = 0; i < availablePlaces.Count(); i++)
                {
                    Queens[nextRange] = availablePlaces[i];
                    if (findPlaceForQueen(nextRange + 1, Queens)) return true;
                }
            }
            return false;
        }

        static void displayDesk(int[] q)
        {
            for (int i = 0; i < q.GetLength(0); i++)
                Console.WriteLine(i + " - " + q[i]);
            Console.WriteLine();
            String repeatedString = new String('x', q.GetLength(0) - 1);
            for (int i = 0; i < q.GetLength(0); i++)
            {
                Console.WriteLine(repeatedString.Insert(q[i], "Q"));
            }

        }

        static void Main(string[] args)
        {
            displayDesk(arrangeNQueens(8));
            Console.ReadKey();
        }
    }
}
