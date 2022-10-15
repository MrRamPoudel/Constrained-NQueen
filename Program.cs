using System;
using System.IO;
using System.Collections.Generic;

namespace NQueen
{
    public class NQueen
    {
        public NQueen(string PathToFile)
        {
            var data = File.ReadLines(PathToFile).Select(x => x.Split(',').ToArray());

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
