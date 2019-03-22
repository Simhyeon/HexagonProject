using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    public AxialCoord currentCoord;
    private RaycastHit ray;

    public void MovePointer()
    {
        //Move pointer to specific area or by grid.
        throw new System.NotImplementedException();
    }

    public void SetTileToPointer()
    {
        if (!CheckEmpty()) { return; }
        //Set Tile to current Pointer and before instantiation. Check if pointer is empty.
        throw new System.NotImplementedException();
    }

    private bool CheckEmpty()
    {
        //Raycast and find if there is alreay something in there.
        return false;
    }
}