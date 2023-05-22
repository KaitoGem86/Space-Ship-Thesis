using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedEnemyPool : MonoBehaviour
{
    [SerializeField] private BaseEnemy enemy;
    [SerializeField] private float dis;
    [SerializeField] private MotherSpaceEnemy motherSpaceEnemy;

    public MotherSpaceEnemy MotherSpaceEnemy
    {
        get { return motherSpaceEnemy; }
    }
    
    private BaseEnemy[] pr_Enemies;


    private int poolSize = 6;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyPool();
    }

    // Update is called once per frame
    void Update()
    {
        SetMove();
    }

    void SetEnemyPool()
    {
        pr_Enemies = new BaseEnemy[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            
            var pos = this.transform.position;

            pos.x += (float)Math.Sin(i * 45) * dis;
            pos.y += (float)Math.Cos(i * 45) * dis;

            var pr_enemy = Instantiate(enemy, pos, Quaternion.identity, this.transform);
            pr_enemy.GetComponent<EnemyShip2>().MotherSpaceEnemy = this.motherSpaceEnemy;
            pr_Enemies[i] = pr_enemy;
        }
        
    }

    void SetMove()
    {
            GameManager.instance.motherSpaceEnemy.MoveStart = true;
    }
}
