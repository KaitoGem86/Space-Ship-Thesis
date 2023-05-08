using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance { get; private set; }

    public PlayerController playerShip;

    private void Awake()
    {
        Instance = this;
    }

    public Vector2 GetInputMove()
    {
        Vector2 pos = new Vector2();

        if (GetInputKeyCode() != new Vector2(0, 0))
        {
            pos = GetInputKeyCode();
            return pos;
        }

        pos = Instance.GetInputMouse();
        return pos;
    }

    public Vector2 GetInputKeyCode()
    {
        Vector2 pos = new Vector2 ();

        pos.x = Input.GetAxis("Horizontal");
        pos.y = Input.GetAxis("Vertical");

        return pos.normalized;
    }

    public Vector2 GetInputMouse()
    {
        Vector2 pos = new Vector2();
        Vector2 screenMousePos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(screenMousePos) - playerShip.transform.position;
        return pos;
    }

    public bool GetInputAttack()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            return true;
        return false;
    }


}
