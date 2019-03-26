using System;
using System.Collections.Generic;
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

    public GameObject Tiles;
    public GameObject defaultGrid;
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

    private HexTile[,] tiles;

    private void OnValidate()
    {
        //if(transform.eulerAngles.x != 0) { Debug.LogError("Set Editor's x rotation to -90. Else script would not work as you expected."); }
        
        tiles = new HexTile[row, column];

        //Removed for Saftey reason.
        //GetComponent<Grid>().cellSize = new Vector3(xInterval, sideLength * 2 , 0);
    }
    
    public void DrawGrids()
    {
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
                Instantiate(defaultGrid, point, Quaternion.identity, Tiles.transform);
            }
        }
    }

    public void ResetGrids()
    {
        if(Tiles.transform.childCount == 0) { return; }
        for (int i = Tiles.transform.childCount; i > 0; --i)
        {
            DestroyImmediate(Tiles.transform.GetChild(0).gameObject);
        }
    }
}