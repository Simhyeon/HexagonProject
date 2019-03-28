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
    //At the first time... do i need to conrfirm this?
    //What if I just send tileArray on game start, into levelmanager
    //LevelEditor is purely editor class and should not interact with level manager on edit time.
    // Or just let confirm to be a pure meaning of confirmation so that editor can know that this map has been confirmed and no need to draw again.
 
    public bool isConfirmed { get; private set; } //Check how can I maintain this value over hard shutdown.
    public HexTile[,] tileArray{get; private set;} //This information should be stored somewhere like... levelMap Class.

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
                Instantiate(defaultGrid, point, Quaternion.identity, Tiles.transform);
            }
        }
    }

    public void ResetGrids()
    {
        SetToChanged();

        if (Tiles.transform.childCount == 0) { return; }
        for (int i = Tiles.transform.childCount; i > 0; --i)
        {
            DestroyImmediate(Tiles.transform.GetChild(0).gameObject);
        }
    }

    private void SetToChanged()
    {
        isConfirmed = false;
    }
    //This method should be differenciated from somewhat send data method.
    public void ConfirmLevel()
    {
        isConfirmed = true;
        HexTile[,] tiles = new HexTile[row, column];
        HexTile iterated;
        foreach(Transform child in transform)
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

            tiles[iterated.coordination.y, iterated.coordination.x] = iterated;
        }
        LevelManager.instance.tiles = tiles;
    }
}