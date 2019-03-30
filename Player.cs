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
    public int moveRange;

    private void Start()
    {
        DisplayMoveRange();
    }

    public void MovePosition(AxialCoord destination, bool straightMove = false)
    {
        if (straightMove)
        {
            transform.position = LevelManager.instance.GetTile(destination).transform.position;
        }
        DisplayMoveRange();
    }

    private void DisplayMoveRange()
    {

    }
}