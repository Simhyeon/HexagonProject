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

    public void MovePosition(AxialCoord destination)
    {

    }
}