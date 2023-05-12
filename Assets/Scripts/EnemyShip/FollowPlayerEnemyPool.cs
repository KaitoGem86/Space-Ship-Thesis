using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEnemyPool : MonoBehaviour
{
    [SerializeField] private BaseEnemy enemy;
    [SerializeField] private float dis;
    [SerializeField] private float timeRate;


    private BaseEnemy[] pr_Enemies;

    private int index = 0;
    private int poolSize = 6;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyPool();
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateEnemy();
    }

    void SetEnemyPool()
    {
        
        pr_Enemies = new BaseEnemy[poolSize];
        for (int i = 0; i < poolSize; i++)
        {

            var pos = this.transform.position;

            pos.x += (float)Math.Sin(i * 45) * dis;
            pos.y += (float)Math.Cos(i * 45) * dis;

            var pr_enemy = Instantiate(enemy, pos, Quaternion.identity);
            pr_Enemies[i] = pr_enemy;
            pr_Enemies[i].gameObject.SetActive(false);

        }

    }

    void InstantiateEnemy()
    {
        if(timeRate > 0)
            timeRate -= Time.deltaTime;
        else
        {
            if (pr_Enemies[index].gameObject.activeSelf) 
            {
                index = (index + 1 ) % poolSize;
                timeRate = 3;
                return; 
            }
            pr_Enemies[index].gameObject.SetActive(true);
            timeRate = 3;
            index = (index++) % poolSize;
        }
    }
}
