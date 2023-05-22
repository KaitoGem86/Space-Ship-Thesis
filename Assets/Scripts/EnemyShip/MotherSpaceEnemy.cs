using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MotherSpaceEnemy : BaseEnemy
{
    private bool moveStart = false;
    private float timer = 5;


    public bool MoveStart
    {
        get { return moveStart; }
        set { moveStart = value; }
    }


    private void Start()
    {
        this.MaxHp = 100;
        this.Hp = this.MaxHp;
        this.Direction = new Vector2(1f, 0);
        this.Speed = 0f;
    }


    private void Update()
    {
        if(MoveStart)
            this.Move();
        //ChangeDirection();

    }

    public override void Move()
    {
        Quaternion t = Quaternion.LookRotation(this.Direction, Vector3.back);
        t.x = 0;
        t.y = 0;
        this.transform.rotation = t;

        Vector2 pos = this.transform.position;
        pos += this.Direction.normalized * this.Speed * Time.deltaTime;
        this.transform.position = pos;
    }

}
