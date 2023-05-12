using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip2 : BaseEnemy
{
    private MotherSpaceEnemy motherSpaceShip;
    private Vector2 ref_dir;



    // Start is called before the first frame update
    void Start()
    {
        motherSpaceShip = GameManager.instance.motherSpaceEnemy;
        ref_dir = motherSpaceShip.Direction * motherSpaceShip.Speed;
        this.Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    public override void Move()
    {
        var n_dir = this.transform.position - motherSpaceShip.transform.position;
        Vector2 dir = new Vector2(n_dir.y, -n_dir.x).normalized;

        this.Direction = dir + ref_dir;
        //this.Speed = 3;
        //Debug.Log(motherSpaceShip.transform.position);
        //Debug.Log(this.transform.position);
        //Debug.Log(this.Direction);

        base.Move();

    }

    int GetDegree()
    {
        Vector2 center = motherSpaceShip.transform.position;
        Vector2 pos = this.transform.position;
        float cos = (pos.x * center.x - pos.y * center.y) / (pos.magnitude * center.magnitude);
        int degree = System.Convert.ToInt32(cos);
        return degree;
    }

    public void SetPosition(BaseEnemy enemy, Vector2 dis)
    {
        Vector2 pos = transform.position;
        pos += dis;
        enemy.transform.position = pos;

    }
}
