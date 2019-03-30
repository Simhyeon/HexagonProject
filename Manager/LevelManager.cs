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
    public HexTile[][] tiles { get; private set; }

    private void Awake()
    {
        LevelStart();
    }

    public void LevelStart()
    {
        tiles = LevelEditor.instance.GetHexArray();
    }
    
    public HexTile GetTile(AxialCoord coordination)
    {
        var tuple = AxialCoordMap.AxialToMatrix(coordination);
        return tiles[tuple.Item1][tuple.Item2];
    }

    public void GetPath(AxialCoord start, AxialCoord end)
    {
        throw new System.NotImplementedException();
    }
}
