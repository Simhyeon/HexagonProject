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

    //Ray ray;
    //RaycastHit hit;

    private void Update()
    {
        //Get MouseKeyDown 
        //if (inputAble)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {

        //    }
        //}
    }
}
