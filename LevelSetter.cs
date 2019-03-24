using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    private AxialCoord currentCoord = new AxialCoord(0,0,0);
    private RaycastHit ray;

    public void MoveRight()
    {
        Vector3 moveAmount = new Vector3(1, 0,-1);
        MovePointer(moveAmount);
    }

    public void MoveLeft()
    {
        Vector3 moveAmount = new Vector3(-1, 0, 1);
        MovePointer(moveAmount);
    }

    //MoveUp and down has critical bug in it.

    public void MoveUp()
    {
        Vector3 moveAmount;
        if (currentCoord.y % 2 == 1)
        {
            moveAmount = new Vector3(0, -1, 1);
        }
        else
        {
            moveAmount = new Vector3(1, -1, 0);
        }
        MovePointer(moveAmount);
    }

    public void MoveDown()
    {
        Vector3 moveAmount;
        if (currentCoord.y % 2 == 0)
        {
            moveAmount = new Vector3(0, 1, -1);
        }
        else
        {
            moveAmount = new Vector3(-1, 1, 0);
        }
        MovePointer(moveAmount);
    }

    private bool CheckEdge(Vector3 moveAmount)
    {
        //Debug.Log(currentCoord.x + moveAmount.x + " - " + (currentCoord.y + moveAmount.y));
        if (currentCoord.y + moveAmount.y < 0 ||
            currentCoord.y + moveAmount.y >= LevelEditor.instance.column)
        {
            //Debug.Log("y Edge : " + (currentCoord.y + moveAmount.y));
            return false;
        }

        //Debug.Log(0 - currentCoord.y / 2);
        //Debug.Log(LevelEditor.instance.row - currentCoord.y / 2);
        
        if (currentCoord.x + moveAmount.x < 0 - (currentCoord.y + (int)moveAmount.y) / 2 ||
            currentCoord.x + moveAmount.x >= LevelEditor.instance.row - (currentCoord.y + (int)moveAmount.y) / 2)
        {
            //Debug.Log("x Edge : " + (currentCoord.x + moveAmount.x));
            //Debug.Log("currentCoord.y + moveAmount.y is :" + (currentCoord.y + (int)moveAmount.y) + "and /2 is" + (currentCoord.y + (int)moveAmount.y) / 2);
            //Debug.Log((0 - (currentCoord.y + (int)moveAmount.y) / 2) + "from ~ to " + (LevelEditor.instance.row - (currentCoord.y + (int)moveAmount.y) / 2));
            return false;
        }
        //Debug.Log("Not an edge");
        return true;
    }

    private void MovePointer(Vector3 moveAmount)
    {
        if (!CheckEdge(moveAmount)) { return; }
        currentCoord.x += (int)moveAmount.x;
        currentCoord.y += (int)moveAmount.y;
        currentCoord.z += (int)moveAmount.z;

        Debug.Log(currentCoord);
        RefreshSetter();
    }

    private void RefreshSetter()
    {
        transform.position = new Vector3(
            LevelEditor.instance.xInterval * (currentCoord.x + currentCoord.y / 2)
            , 0
            , LevelEditor.instance.yInterval * -currentCoord.y);

        if(currentCoord.y % 2 == 1)
        {
            //Debug.Log("On even line");
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