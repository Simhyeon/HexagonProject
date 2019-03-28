using System;
using System.Collections;
using System.Collections.Generic;
using AxialCoordinationSystem;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public bool isRegistered;
    public AxialCoord coordination { get; private set; }
    public GameObject structureParent; //Consider make this into private and serializeField
    public HexTileData data;

    public void Register(AxialCoord coord)
    {
        isRegistered = true;
        if(coordination != null)
        {
            Debug.LogError("Double register occured please check your process.");
            throw new System.InvalidOperationException();
        }
        coordination = new AxialCoord(coord);
    }

    private void OnValidate()
    {
        if(coordination != null)
        {
            Debug.LogError("You should not change axial coordination value of the tile on editor.");
        }

        if(data == null)
        {
            Debug.LogError("Your tile object should have tile data to work as expected.");
            return;
        }
        
        GetComponent<MeshRenderer>().material = data.material;
        if(data.hexTileStructure == null)
        {
            return;
        }
        Instantiate(data.hexTileStructure, structureParent.transform);
    }
}

namespace AxialCoordinationSystem
{
    public class AxialCoord
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }

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

        public AxialCoord(int x, int y, int z)
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

        public static AxialCoord operator +(AxialCoord a, AxialCoord b)
        {
            AxialCoord c = new AxialCoord();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            c.z = a.z + b.z;
            return c;
        }

        public static bool operator ==(AxialCoord a, AxialCoord b)
        {
            if(a.x == b.x &&
                a.y == b.y &&
                a.z == b.z)
            {
                    return true;
            }
            return false;
        }
    }

    public static class AxialCoordMap
    {
        public static AxialCoord[] GetSurroundingGrids(AxialCoord position, int range)
        {
            throw new System.NotImplementedException();
        }

        public static AxialCoord[] GetPath(AxialCoord start, AxialCoord goal)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Change matrix coord into axial coord. Only works for rectangular shape.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static AxialCoord MatrixToAxial(int row, int column, AxialOrigin origin = AxialOrigin.TopLeft, bool fatOddLine = true)
        {
            throw new System.NotImplementedException();
        }

        public enum AxialOrigin
        {
            TopLeft,
            TopRight,
            DownLeft,
            DownRight
        }
    }
}