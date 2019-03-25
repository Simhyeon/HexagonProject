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
    public LevelSetter pointer;
    
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

        GetComponentInChildren<LevelSetter>().transform.position = new Vector3(0, 0, 0);
        tiles = new HexTile[row, column];

        //Removed for Saftey reason.
        //GetComponent<Grid>().cellSize = new Vector3(xInterval, sideLength * 2 , 0);
    }
    
    //public void SwitchGrid()
    //{
    //    GetComponent<Grid>().enabled = !GetComponent<Grid>().enabled;
    //}

    public string DisplayCoord()
    {
        return pointer.coord.ToString();
    }
    
    [System.Obsolete]
    public void UpdateGrid()
    {
        GetComponent<Grid>().cellSize = new Vector3(xInterval, sideLength * 2, 0);
    }

    public void ResetPointer()
    {
        pointer.Reset();
    }

    public void MovePointerRight()
    {
        pointer.MoveRight();
    }

    public void MovePointerLeft()
    {
        pointer.MoveLeft();
    }

    public void MovePointerUp()
    {
        pointer.MoveUp();
    }

    public void MovePointerDown()
    {
        pointer.MoveDown();
    }

    //public void DrawGrids()
    //{
    //    Debug.Log("Currently on working");
    //    return;

    //    //ResetGrids();

    //    //Debug.Log("Draw Grids");
    //    //Vector3 point;
    //    //for (int i = 0; i < row; i++)
    //    //{
    //    //    for (int j = 0; j < column; j++)
    //    //    {
    //    //        point = new Vector3(
    //    //            LevelEditor.instance.xInterval * j
    //    //            , 0
    //    //            , LevelEditor.instance.yInterval * -i);
    //    //        if(i % 2 == 1)
    //    //        {
    //    //            point.x += LevelEditor.instance.xInterval * 0.5f;
    //    //        }
    //    //        Instantiate(defaultGrid, point, Quaternion.identity, gridMap.transform);
    //    //    }
    //    //}
    //}

    //private void ResetGrids()
    //{
    //    foreach (Transform child in gridMap.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //}

    private void Start()
    {
        GetComponentInChildren<LevelSetter>().gameObject.SetActive(false);
        //And Make Static 2d array or arrays of arrays or just give tiles array to some other place. 
    }
}