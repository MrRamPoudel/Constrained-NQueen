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
        }
    }
}

