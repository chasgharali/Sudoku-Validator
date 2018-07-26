using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTest
{
  class SudokuPuzzleValidator
  {
    static void Main(string[] args)
    {

      int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


      int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

      int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

      int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };

      
      Console.WriteLine(ValidateSudoku(goodSudoku1));
      Console.WriteLine(ValidateSudoku(goodSudoku2));
      Console.WriteLine(ValidateSudoku(badSudoku1));
      Console.WriteLine(ValidateSudoku(badSudoku2));
    }

    static string ValidateSudoku(int[][] puzzle)
    {
      int col = 0, row = 0;
      int Size = puzzle.GetLength(0);
      for (int i = 0; i < Size; i++)
      {
        if (CheckRC(i, puzzle))
          continue;
        else
          return "This isn't supposed to validate! It's a bad sudoku!";
      }
      return "This is supposed to validate! It's a good sudoku!";
    }

    /// <summary>
    /// this function is for checking duplicate in row and colum 
    /// </summary>
    static bool CheckRC(int x, int[][] sudoku)
    {
      int Size = sudoku.GetLength(0);
      int[] arrR = new int[Size];
      int[] arrC = new int[Size];
      for (int i = 0; i < Size; i++)
      {
        arrR[i] = sudoku[x][i];
        arrC[i] = sudoku[i][x];
      }
      int countR = 0, countC = 0;
      for (int i = 0; i < Size; i++)
      {
        if ((arrR[i] < 10 && arrR[i] > 0) && (arrC[i] < 10 && arrC[i] > 0))
        {
          countR = frequency(arrR, Size, arrR[i]);
          countC = frequency(arrC, Size, arrC[i]);
          if (countR > 1 || countC > 1)
            return false;
        }
        else
          return false;
      }
      return true;
    }
    static int frequency(int[] a, int n, int x)
    {
      int count = 0;
      for (int i = 0; i < n; i++)
        if (a[i] == x)
          count++;
      return count;
    }
  }
}