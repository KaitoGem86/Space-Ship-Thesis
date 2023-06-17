using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedEnemyPool : EnemyPool
{
    [SerializeField] private BaseEnemy enemy;
    [SerializeField] private float dis = 2;
    //[SerializeField] private MotherSpaceEnemy motherSpaceEnemy;

    //public MotherSpaceEnemy MotherSpaceEnemy
    //{
    //    get { return motherSpaceEnemy; }
    //}

    private List<BaseEnemy> pr_Enemies;


    private int col = 4;
    private int row = 3;

    private int poolSize;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyPool();
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //SetMove();
        Move();
    }

    void SetEnemyPool()
    {
        poolSize = col * row;
        this.num = poolSize;
        var size = enemy.GetComponent<SpriteRenderer>().size;
        pr_Enemies = new List<BaseEnemy>();
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                var pos = this.transform.position;

                pos.x += i * size.x / 3 + dis;
                pos.y += j * size.y / 3 + dis;

                var pr_enemy = Instantiate(enemy, pos, Quaternion.identity, this.transform);
                //pr_enemy.GetComponent<EnemyShip2>().MotherSpaceEnemy = this.gameObject;
                //pr_Enemies[i] = pr_enemy;
                pr_enemy.Pool = this;
                pr_Enemies.Add(pr_enemy);
                //pr_Enemies[i].Pool = this;
            }
        }

    }

    void SetMove()
    {
        GameManager.instance.motherSpaceEnemy.MoveStart = true;
    }


    void Move()
    {
        Vector3 pos = this.transform.position;
        if (pos.y <= 2)
        {
            pos.y = 2;
            this.transform.position = pos;
            return;
        }
        pos.y -= Time.deltaTime * 2;
        this.transform.position = pos;
    }

    public override void SetPosition()
    {
        this.transform.position = new Vector3(-2.5f, 10, 0);
    }

    public override void SetEnemy()
    {
        this.num = this.pr_Enemies.Count;
        foreach (var go in pr_Enemies)
        {
            if (!go.gameObject.activeSelf)
            {
                go.gameObject.SetActive(true);
                go.Hp = go.MaxHp;
                go.UpdateHealth();
            }
        }
    }
}
