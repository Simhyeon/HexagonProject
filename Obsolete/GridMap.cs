using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class GridMap : MonoBehaviour
{
    private static GridMap _instance;
    public static GridMap instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GridMap>() as GridMap;
            }
            return _instance;
        }
    }

}
