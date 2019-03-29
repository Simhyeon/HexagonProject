using UnityEngine;

public class Player : MonoBehaviour 
{
    private static Player player;
    public static Player instance
    {
        get
        {
            if(player == null)
            {
                player = FindObjectOfType<InputManager>();
            }

            return player;
        }
    } 

    public void MovePosition(AxialCoord destination)
    {

    }
}