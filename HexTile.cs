using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public AxialCoord coordination;
    //public Graphical Component.
}

public class AxialCoord
{
    private int _x;
    private int _y;
    private int _z;

    public int x
    {
        get { return _x; }
        set { _x = value; }
    }
    public int y
    {
        get { return _y; }
        set { _y = value; }
    }
    public int z
    {
        get { return _z; }
        set { _z = value; }
    }

    public override string ToString()
    {
        return "[x : " + x + "] | [y : " + y + "]";
    }

    public AxialCoord(int x, int y, int z)
    {
        this._x = x;
        this._y = y;
        this._z = z;
    }

    public void SetCoord(Vector3 value)
    {
        x = (int)value.x;
        y = (int)value.y;
        z = (int)value.z;
    }

    public Vector2 GetAxial()
    {
        return new Vector2(_x, _y);
    }

    public Vector3 GetCube()
    {
        return new Vector3(_x, _y, _z);
    }

    public string GetCubeString()
    {
        return "[x : " + x + "] | [y : " + y + "] | [z : " + z + "]";
    }
}