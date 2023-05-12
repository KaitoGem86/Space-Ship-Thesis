using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MotherSpaceEnemy : BaseEnemy
{
    private bool moveStart = false;
    public bool MoveStart
    {
        get { return moveStart; }
        set { moveStart = value; }
    }


    private void Start()
    {
        this.Direction = new Vector2(0.1f, 0);
        this.Speed = 0f;
    }


    private void Update()
    {
        if(MoveStart)
            this.Move();
    }

}
