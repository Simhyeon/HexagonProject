using System;
using System.Collections.Generic;
using UnityEngine;

// This namespace is highly aimed for specific purposes and current build of game. 
// So definitely not compatible with different hex system;
namespace AxialCoordinationSystem
{
    [System.Serializable]
    public class AxialCoord
    {
        public int x;// { get; private set; }
        public int y;// { get; private set; }
        public int z;// { get; private set; }

        public override string ToString()
        {
            return "[x : " + x + "] | [y : " + y + "]";
        }

        public AxialCoord(AxialCoord coord)
        {
            x = coord.x;
            y = coord.y;
            z = coord.z;
        }

        public AxialCoord(int x, int y)
        {
            this.x = x;
            this.y = y;
            z = -x - y;
        }

        public AxialCoord(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void HardCopy(int x, int y)
        {
            this.x = x;
            this.y = y;
            z = -x - y;
        }

        public void HardCopy(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetCoord(Vector3 value)
        {
            x = (int)value.x;
            y = (int)value.y;
            z = (int)value.z;
        }

        public Vector2 GetAxial()
        {
            return new Vector2(x, y);
        }

        public Vector3 GetCube()
        {
            return new Vector3(x, y, z);
        }

        public string GetCubeString()
        {
            return "[x : " + x + "] | [y : " + y + "] | [z : " + z + "]";
        }

        // public static AxialCoord operator +(AxialCoord a, AxialCoord b)
        // {
        //     AxialCoord c = new AxialCoord();
        //     c.x = a.x + b.x;
        //     c.y = a.y + b.y;
        //     c.z = a.z + b.z;
        //     return c;
        // }

        // public static AxialCoord operator -(AxialCoord a, AxialCoord b)
        // {
        //     AxialCoord c = new AxialCoord();
        //     c.x = a.x - b.x;
        //     c.y = a.y - b.y;
        //     c.z = a.z - b.z;
        //     return c;
        // }

        //public static bool operator ==(AxialCoord a, AxialCoord b)
        //{
        //    if(a.x == b.x &&
        //        a.y == b.y &&
        //        a.z == b.z)
        //    {
        //            return true;
        //    }
        //    return false;
        //}

        //public static bool operator !=(AxialCoord a, AxialCoord b)
        //{
        //    if (a.x != b.x ||
        //        a.y != b.y ||
        //        a.z != b.z)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool Compare(AxialCoord compared)
        {
            if (x == compared.x &&
                y == compared.y &&
                z == compared.z)
            {
                return true;
            }
            return false;
        }
    }

    public static class AxialCoordMap
    {
        public static int ManhattanDistance(AxialCoord start, AxialCoord end)
        {
            return (Math.Abs(start.x - end.x) + Math.Abs(start.y - end.y) + Math.Abs(start.z - end.z)) / 2;
        }

        public static AxialCoord[] GetGridsWithinRange(AxialCoord position, int range = 1)
        {
            //List<AxialCoord> list = new List<AxialCoord>();
            //for (int x = position.x - range; x <= position.x + range; x++)
            //{
            //    for (int y = position.y - range; y <= position.y + range; y++)
            //    {
            //        for (int z = position.z - range; z <= position.z + range; z++)
            //        {
            //            if (x + y + z == 0)
            //            {
            //                list.Add(new AxialCoord(x, y, z));
            //            }
            //        }
            //    }
            //}
            //return list.ToArray();
            
            List<AxialCoord> list = new List<AxialCoord>();
            for (int x = - range; x <= range; x++)
            {
                for (int y = Math.Max(-range, -x - range); y <= Math.Min(+range, -x + range); y += 1)
                {
                    int z = -x - y;
                    list.Add(new AxialCoord(x + position.x, y + position.y, z + position.z));
                }
            }
            return list.ToArray();
        }

        // This method might have to interact with hexTile to check if it is obstacle or not.
        // So consider to move this code into some other class inside such as level manager.
        //public static AxialCoord[] GetPath(AxialCoord start, AxialCoord goal)
        //{
        //    throw new System.NotImplementedException();
        //}

        // //Applied for 2d array map storage structure. Should be modified for array or arrays map storage structure.
        // Also original.x/2 is equal to Math.floor value since c# deletes every digis after integer value. 
        public static AxialCoord MatrixToAxial(int row, int column)
        {
            return new AxialCoord(column - row / 2, row);
        }

        public static Tuple<int, int> AxialToMatrix(AxialCoord original)
        {
            return Tuple.Create(original.y, original.x + original.y / 2);
        }
    }
}