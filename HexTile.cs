using System;
using System.Collections;
using System.Collections.Generic;
using AxialCoordinationSystem;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public bool isRegistered;
    public AxialCoord coordination;// { get; private set; }
    public GameObject structureParent; //Consider make this into private and serializeField
    public HexTileData data;

    private Material originalMaterial;
    public Material highlightedMaterial;

    public bool isHighlighted { get; private set; }
    public bool isSteppable { get; private set; }

    private void Start()
    {
        originalMaterial = GetComponent<MeshRenderer>().material;
    }

    public void Register(int row, int column)
    {
        if(isRegistered != false)
        {
            Debug.LogError("Double register occured please check your process.");
            throw new System.InvalidOperationException();
        }
        isRegistered = true;
        coordination = AxialCoordMap.MatrixToAxial(row, column);
    }

    private void OnValidate()
    {
        // Change Draw method first.
        //if(coordination != null)
        //{
        //    Debug.LogError("You should not change axial coordination value of the tile on editor.");
        //}

        if(data == null)
        {
            Debug.LogError("Your tile object should have tile data to work as expected.");
            return;
        }
        
        GetComponent<MeshRenderer>().material = data.material;
        if(data.hexTileStructure == null)
        {
            return;
        }
        Instantiate(data.hexTileStructure, structureParent.transform);
    }

    // Check the levelmanager code for the reason why the return value is hextile. 
    public HexTile SetToHighlighted()
    {
        GetComponent<MeshRenderer>().material = highlightedMaterial;
        isHighlighted = true;
        return this;
    }

    public void SetToSteppable()
    {
        if(!data.isObstacle)
            isSteppable = true;
    }

    public void Reset()
    {
        GetComponent<MeshRenderer>().material = originalMaterial;
        isSteppable = false;
        isHighlighted = false;
    }
}