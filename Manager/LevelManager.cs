using System.Collections;
using System.Collections.Generic;
using AxialCoordinationSystem;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
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
    public HexTile[,] tiles { get; private set; }

    public void LevelStart(HexTile[,] levelTiles)
    {
        tiles = levelTiles; //Immutable
    }

    public void GetPath(AxialCoord start, AxialCoord end)
    {
        throw new System.NotImplementedException();
    }
}
