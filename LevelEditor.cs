using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor : MonoBehaviour
{
    private static LevelEditor _levelEditor;
    public static LevelEditor levelEditor
    {
        get{
            if(_levelEditor == null){
                _levelEditor = FindObjectOfType<LevelEditor>();
            }
            return _levelEditor;
        }
    }

    public GameObject defaultGrid;
    public int row;
    public int column;
    public float sideLength;

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