using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager inputManager;
    public static InputManager instance
    {
        get
        {
            if(inputManager == null)
            {
                inputManager = FindObjectOfType<InputManager>();
            }
            return inputManager;
        }
    }
    public bool inputAble;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        inputAble = true;
    }

    private void Update()
    {
        //Get MouseKeyDown 
        if (inputAble)
        {
           if (Input.GetMouseButtonDown(0))
           {
               ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               if (Physics.Raycast(ray, out hit, 100f))
               {
                   if (hit.collider.tag == "Tile")
                   {
                        Debug.Log(hit.collider.GetComponent<HexTile>().coordination);
                       Player.instance.MovePosition(hit.collider.GetComponent<HexTile>().coordination, true);
                   }
               }
           }
        }
    }
}
