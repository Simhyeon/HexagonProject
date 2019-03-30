using System;
using System.Collections.Generic;
using AxialCoordinationSystem;
using UnityEngine;
using UnityEditor;

public class LevelEditor : MonoBehaviour
{
    private static LevelEditor _instance;
    public static LevelEditor instance
    {
        get{
            if(_instance == null){
                _instance = FindObjectOfType<LevelEditor>();
            }
            return _instance;
        }
    }

    public GameObject tilesParent;
    public GameObject defaultGrid;
    public bool isConfirmed { get; private set; } //Check how can I maintain this value over hard shutdown.

    public int row;
    public int column;
    public float sideLength;
    public float xInterval
    {
        get
        {
            return (float)Math.Sqrt(3) * sideLength;
        }
    }
    public float yInterval
    {
        get
        {
            return sideLength * 1.5f;
        }
    }
    
    public void DrawGrids()
    {
        //SetToChanged() //Duplicate with resetGrids
        ResetGrids();

        Debug.Log("Draw Grids");
        Vector3 point;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                point = new Vector3(
                    xInterval * j
                    , 0
                    , yInterval * -i);
                if (i % 2 == 1)
                {
                    point.x += xInterval * 0.5f;
                }
                GameObject tile = Instantiate(defaultGrid, point, Quaternion.identity, tilesParent.transform);
                tile.GetComponent<HexTile>().Register(i,j);
            }
        }
    }

    public void ResetGrids()
    {
        SetToChanged();

        if (tilesParent.transform.childCount == 0) { return; }
        for (int i = tilesParent.transform.childCount; i > 0; --i)
        {
            DestroyImmediate(tilesParent.transform.GetChild(0).gameObject);
        }
    }

    private void SetToChanged()
    {
        isConfirmed = false;
    }
    
    public void ConfirmLevel()
    {
        isConfirmed = true;
    }

    public HexTile[][] GetHexArray()
    {
        HexTile[][] tiles = new HexTile[row][];
        for (int i = 0; i < row; i++)
        {
            tiles[i] = new HexTile[column];
        }

        HexTile iterated;
        foreach(Transform child in tilesParent.transform)
        {
            iterated = child.GetComponent<HexTile>();
            if(iterated == null)
            {
                Debug.LogError("Hextile not found : " + child.name);
            }
            if(!child.GetComponent<HexTile>().isRegistered)
            {
                Debug.LogError("Unregistered object found. : " + child.name);    
            }
            var index = AxialCoordMap.AxialToMatrix(iterated.coordination);
            //Debug.Log(index.Item1 + " | " + index.Item2);
            tiles[index.Item1][index.Item2] = iterated;
        }
        return tiles;
    }
}