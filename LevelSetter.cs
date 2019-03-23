using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    private AxialCoord currentCoord = new AxialCoord(0,0,0);
    private RaycastHit ray;

    public void MoveRight()
    {
        Vector2 moveAmount = new Vector2(1, 0);
        MovePointer(moveAmount);
    }

    public void MoveLeft()
    {
        Vector2 moveAmount = new Vector2(-1, 0);
        MovePointer(moveAmount);
    }

    public void MoveUp()
    {
        Vector2 moveAmount = new Vector2(0, -1);
        MovePointer(moveAmount);
    }

    public void MoveDown()
    {
        Vector2 moveAmount = new Vector2(0, 1);
        MovePointer(moveAmount);
    }

    private bool CheckEdge(Vector2 moveAmount)
    {
        //Debug.Log(currentCoord.x + moveAmount.x + " - " + (currentCoord.y + moveAmount.y));
        if (currentCoord.y + moveAmount.y < 0 ||
            currentCoord.y + moveAmount.y > LevelEditor.instance.column) { return false; }

        //Debug.Log(0 - currentCoord.y / 2);
        //Debug.Log(LevelEditor.instance.row - currentCoord.y / 2);
        
        if (currentCoord.x + moveAmount.x < 0 - currentCoord.y / 2 ||
            currentCoord.x + moveAmount.x > LevelEditor.instance.row - currentCoord.y / 2) { return false; }

        //Debug.Log("Not an edge");
        return true;
    }

    private void MovePointer(Vector2 moveAmount)
    {
        if (!CheckEdge(moveAmount)) { return; }
        currentCoord.x += (int)moveAmount.x;
        currentCoord.y += (int)moveAmount.y;
        RefreshSetter();
    }

    private void RefreshSetter()
    {
        transform.position = new Vector3(
            LevelEditor.instance.xInterval * (currentCoord.x + currentCoord.y / 2)
            , 0
            , LevelEditor.instance.yInterval * -currentCoord.y);

        if(currentCoord.x % 2 == 1)
        {
            transform.Translate(new Vector2(LevelEditor.instance.xInterval * 0.5f,0));
        }
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