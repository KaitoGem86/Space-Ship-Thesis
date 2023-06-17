using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip2 : BaseEnemy
{
    [SerializeField] EnemyWeapon weapon;


    private Vector2 ref_dir;

    private float timer = 2;

    // Start is called before the first frame update
    void Start()
    {
        this.MaxHp = 20;
        this.Hp = this.MaxHp;
        timer = UnityEngine.Random.Range(4, 6);
        //motherSpaceShip = GameManager.instance.motherSpaceEnemy;
        //ref_dir = motherSpaceShip.Direction * motherSpaceShip.Speed;
        this.Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //this.Move();
        this.Rotate();
        Attack();
    }

    public override void Rotate()
    {
        Quaternion t = Quaternion.LookRotation(Vector2.down, Vector3.back);
        t.x = 0;
        t.y = 0;
        this.transform.rotation = t;
    }

    protected override void Attack()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 2;
            weapon.Attack();
        }
    }
}
