using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip2 : BaseEnemy
{

    private MotherSpaceEnemy motherSpaceShip;
    private Vector2 ref_dir;


    public MotherSpaceEnemy MotherSpaceEnemy
    {
        get { return motherSpaceShip; }
        set { motherSpaceShip = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.MaxHp = 20;
        this.Hp = this.MaxHp;

        //motherSpaceShip = GameManager.instance.motherSpaceEnemy;
        ref_dir = motherSpaceShip.Direction * motherSpaceShip.Speed;
        this.Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Rotate();
    }

    public override void Move()
    {
        var n_dir = this.transform.position - motherSpaceShip.transform.position;
        Vector2 dir = new Vector2(n_dir.y, -n_dir.x);

        this.Direction = dir/* + ref_dir*/;
        this.Speed = 3;

        //Debug.Log(motherSpaceShip.transform.position);
        //Debug.Log(this.transform.position);
        //Debug.Log(this.Direction);

        base.Move();

    }

    public override void Rotate()
    {
        Quaternion t = Quaternion.LookRotation(this.Direction, Vector3.back);
        t.x = 0;
        t.y = 0;
        this.transform.rotation = t;
    }

    int GetDegree()
    {
        Vector2 center = motherSpaceShip.transform.position;
        Vector2 pos = this.transform.position;
        float cos = (pos.x * center.x - pos.y * center.y) / (pos.magnitude * center.magnitude);
        int degree = System.Convert.ToInt32(cos);
        return degree;
    }

}
