using System;
using System.IO;
using System.Collections.Generic;

namespace NQueen
{
    public class NQueen
    {
        public NQueen(string PathToFile)
        {
            var data = File.ReadLines(PathToFile).Select(x => x.Split(',').ToList());
            BoardSize = data.ElementAt(0).Count();
            LocateQueen(data);
            QueenPositions = new Dictionary<Tuple<int, int>, int>();
            QueenPositions.Add(Tuple.Create(QueenRow,QueenCol), 1);
            QueenBoard = new int[BoardSize, BoardSize];
            QueenBoard[QueenRow,QueenCol] = 1;
        }

        //Finds the index at which first queen is located x and y
        private void LocateQueen(IEnumerable<List<string>> FromFile)
        {
            for (int i = 0; i < BoardSize; ++i)
            {
                for (int j = 0; j < BoardSize; ++j)
                {
                    if (FromFile.ElementAt(i).ElementAt(j) == "1")
                    {
                        QueenRow = i;
                        QueenCol = j;
                        return;
                    }
                }
            }
        }

        //Check if a placement is valid by checking the rows and the diagonals
        private bool IsValid(int row, int col)
        {
            foreach (var x in QueenPositions)
            {
                if (row == x.Key.Item1)
                {
                    return false;
                }
                if (Math.Abs(x.Key.Item1 - row) == Math.Abs(x.Key.Item2 - col))
                {
                    return false;
                }
            }
            return true;
        }
        private bool Backtrack(int col)
        {
            for (int i = 0; i < BoardSize; ++i)
            {
                if (col == QueenCol)
                    ++col;
                if (col >= BoardSize)
                    return true;
                if(IsValid(i, col))
                {
                    //Add the valid placement
                    QueenPositions.Add(Tuple.Create(i, col), 1);
                    if (Backtrack(col + 1))
                        return true;
                    //If the next placement is invalid, backtrack to previous column
                    QueenPositions.Remove(Tuple.Create(i, col));
                }
            }
            return false;

        }
        //Call this function to solve the problem
        public void SolveProblem()
        {
            if (!Backtrack(0))
            {
                Console.WriteLine("Solution does not exist");
                return;
            }
            //Build a board and show it
            BuildBoard();
            ShowBoard();
        }
        //Create a board with queens
        private void BuildBoard()
        {
            foreach(var AllQueens in QueenPositions)
            {
                QueenBoard[AllQueens.Key.Item1, AllQueens.Key.Item2] = AllQueens.Value;
            }
        }
        //Print the board
        private void ShowBoard()
        {
            for(int i = 0; i< BoardSize; ++i)
            {
                for (int j = 0; j< BoardSize; ++j)
                {
                    Console.Write("{0} ", QueenBoard[i, j]);
                }
                Console.Write('\n');
            }
        }
        //Position of all the queens
        private Dictionary<Tuple<int, int>, int> QueenPositions = null!;
        //Board information
        private int[,] QueenBoard = null!;
        private int BoardSize = 0;
        private int QueenCol = 0;
        private int QueenRow = 0;
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            var FileName = args[0];
            NQueen prog = new NQueen(FileName);
            prog.SolveProblem();
        }
    }
}

