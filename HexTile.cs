using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public AxialCoord coordination;
    //public Graphical Component.
}

//[System.Serializable]
public struct AxialCoord
{
    private int x;
    private int y;
    private int z;

    public AxialCoord(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector2 GetAxial()
    {
        return new Vector2(x, y);
    }

    public Vector3 GetCube()
    {
        return new Vector3(x, y, z);
    }
}