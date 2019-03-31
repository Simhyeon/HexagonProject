using UnityEngine;
using AxialCoordinationSystem;

public class Player : MonoBehaviour 
{
    private static Player player;
    public static Player instance
    {
        get
        {
            if(player == null)
            {
                player = FindObjectOfType<Player>();
            }

            return player;
        }
    }
    public AxialCoord playerPosition;
    public int moveRange;

    private void Start()
    {
        playerPosition = new AxialCoord(0, 0);
        DisplayMoveRange();
    }

    public void MovePosition(AxialCoord destination, bool straightMove = false)
    {
        playerPosition.HardCopy(destination.x, destination.y);
        //Debug.Log(playerPosition);
        if (straightMove)
        {
            transform.position = LevelManager.instance.GetTile(destination).transform.position;
        }
        DisplayMoveRange();
    }

    private void DisplayMoveRange()
    {
        LevelManager.instance.DisplayRange(playerPosition, moveRange);
    }
}