using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlueButtonLib
{
    public sealed class BlueLatinSquare : IEquatable<BlueLatinSquare>
    {
        public int this[int row, int col] => _cells[(row % 4 + 4) % 4 * 4 + (col % 4 + 4) % 4];
        public static readonly ReadOnlyCollection<BlueLatinSquare> AllSquares = BLSData.GenerateAllSquares();
        private readonly ReadOnlyCollection<int> _cells;

        internal BlueLatinSquare(ReadOnlyCollection<int> rows)
        {
            _cells = rows;
        }

        public static BlueLatinSquare Random(int seed)
        {
            Random rng = new Random(seed);
            return AllSquares[rng.Next(0, AllSquares.Count)];
        }

        public OrderedPair[] LocationsOf(int toFind)
        {
            if(!new int[] { 0, 1, 2, 3 }.Contains(toFind))
                throw new ArgumentException($"Cannot find {toFind} in a Latin Square!");

            List<OrderedPair> locs = new List<OrderedPair>();

            for(int x = 0; x < 4; x++)
                for(int y = 0; y < 4; y++)
                    if(this[x, y] == toFind)
                        locs.Add(new OrderedPair() { X = x, Y = y });
            return locs.ToArray();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BlueLatinSquare);
        }

        public bool Equals(BlueLatinSquare other)
        {
            return other != null &&
                _cells.SequenceEqual(other._cells);
        }

        public override int GetHashCode()
        {
            return 908360967 + EqualityComparer<ReadOnlyCollection<int>>.Default.GetHashCode(_cells);
        }

        public static bool operator ==(BlueLatinSquare left, BlueLatinSquare right)
        {
            return EqualityComparer<BlueLatinSquare>.Default.Equals(left, right);
        }

        public static bool operator !=(BlueLatinSquare left, BlueLatinSquare right)
        {
            return !(left == right);
        }
    }
}
