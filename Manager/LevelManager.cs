using System;
using System.Collections;
using System.Collections.Generic;
using AxialCoordinationSystem;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Singleton
    private static LevelManager levelManager;
    public static LevelManager instance
    {
        get
        {
            if(levelManager == null)
            {
                levelManager = FindObjectOfType<LevelManager>();
            }
            return levelManager;
        }
    }
    //Hextiles array that has all hex tiles objects. 
    public HexTile[][] tiles { get; private set; }

    private void Awake()
    {
        LevelStart(); //Initiation.
    }

    public void LevelStart()
    {
        //Get hex tiles into 2d array from leveleditor.
        tiles = LevelEditor.instance.GetHexArray();
    }
    //Get tile object with coordination.
    public HexTile GetTile(AxialCoord coordination)
    {
        var tuple = AxialCoordMap.AxialToMatrix(coordination);
        return tiles[tuple.Item1][tuple.Item2];
    }
    //This is the part that should be modified, use daikstra algorithm.
    public void GetPath(AxialCoord start, AxialCoord end)
    {
        throw new System.NotImplementedException();
    }
    //Display range with circular shape.
    public void DisplayRange(AxialCoord center ,int range, bool includeCenter = false)
    {
        //Remove Current Highlight // This is purley For Debug Purpose. 
        ClearHighLight();

        AxialCoord[] iterated =  AxialCoordMap.GetGridsWithinRange(center, range);
        var index = Tuple.Create(0, 0);
        foreach (var item in iterated)
        {
            index = AxialCoordMap.AxialToMatrix(item);
            try
            {
                tiles[index.Item1][index.Item2].SetToHighlighted().SetToSteppable();
            }
            catch
            {
                //Do Nothing.
                //Something inside my soul says it is not the best way to handle null index error... still I'll just stick to it.
            }
        }
        // Display range including center, used to display range which is not for player movement.
        if (!includeCenter)
        {
            tiles[AxialCoordMap.AxialToMatrix(center).Item1][AxialCoordMap.AxialToMatrix(center).Item2].Reset();
        }
        //throw new System.NotImplementedException();
    }

    public void ClearHighLight()
    {
        foreach (var tileArray in tiles)
        {
            foreach (var tile in tileArray)
            {
                if (tile.isHighlighted)
                {
                    tile.Reset();
                }
            }
        }
    }
}
