using System;
using System.Collections.Generic;

namespace BlueButtonLib
{
    public class Cube : IEquatable<Cube>
    {
        internal Cube(int[] faces)
        {
            if(faces?.Length != 6)
                throw new ArgumentException($"Bad number of faces: {faces?.Length}");
            Top = faces[0];
            Bottom = faces[1];
            Left = faces[2];
            Right = faces[3];
            Back = faces[4];
            Front = faces[5];
        }

        public int Top { get; }
        public int Bottom { get; }
        public int Left { get; }
        public int Right { get; }
        public int Back { get; }
        public int Front { get; }

        public Cube Rotate(Rotation r) => r switch
        {
            Rotation.XY => new Cube(new int[] { Top, Bottom, Front, Back, Left, Right }),
            Rotation.YX => new Cube(new int[] { Top, Bottom, Back, Front, Right, Left }),
            Rotation.ZY => new Cube(new int[] { Back, Front, Left, Right, Bottom, Top }),
            Rotation.YZ => new Cube(new int[] { Front, Back, Left, Right, Top, Bottom }),
            _ => new Cube(new int[] { Top, Bottom, Left, Right, Back, Front }),
        };

        public enum Rotation
        {
            XY,
            YX,
            ZY,
            YZ
        }

        public override string ToString()
        {
            return $"(T:{Top} B:{Bottom} L:{Left} R:{Right} B:{Back} F:{Front})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cube);
        }

        public bool Equals(Cube other)
        {
            return other != null &&
                   Top == other.Top &&
                   Bottom == other.Bottom &&
                   Left == other.Left &&
                   Right == other.Right &&
                   Back == other.Back &&
                   Front == other.Front;
        }

        public override int GetHashCode()
        {
            int hashCode = 321208629;
            hashCode = hashCode * -1521134295 + Top.GetHashCode();
            hashCode = hashCode * -1521134295 + Bottom.GetHashCode();
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + Back.GetHashCode();
            hashCode = hashCode * -1521134295 + Front.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Cube left, Cube right)
        {
            return EqualityComparer<Cube>.Default.Equals(left, right);
        }

        public static bool operator !=(Cube left, Cube right)
        {
            return !(left == right);
        }
    }
}
