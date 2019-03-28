using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="HexTileData" ,menuName ="HexTileData")]
public class HexTileData : ScriptableObject
{
    //public Mesh objectMesh; // or 
    public HexTileStructure hexTileStructure;
    public Material material;
    public TerrainType terrainType;
    public bool isObstacle;
}

public enum TerrainType
{
    Plain,
    Forest,
    Swamp
    //Etc...
}