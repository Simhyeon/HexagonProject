using System;
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

    private void OnEnable()
    {
        tiles = new HexTile[row, column];
    }

    private void Start()
    {
        GetComponentInChildren<LevelSetter>().gameObject.SetActive(false);
        //And Make Static 2d array or arrays of arrays or just give tiles array to some other place. 
    }
}