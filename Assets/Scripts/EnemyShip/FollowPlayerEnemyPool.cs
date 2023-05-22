using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEnemyPool : MonoBehaviour
{
    [SerializeField] private BaseEnemy enemy;
    [SerializeField] private float dis = 2f;
    [SerializeField] private float timeRate;
    [SerializeField] private MotherSpaceEnemy motherSpaceEnemy;

    private BaseEnemy[] pr_Enemies;

    private Vector2 pos = new Vector2();
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
        if(CheckInstance())
        {
            pos = this.transform.position;
            InstantiateEnemy();
        }
    }

    void SetEnemyPool()
    {
        
        pr_Enemies = new BaseEnemy[poolSize];
        for (int i = 0; i < poolSize; i++)
        {

            pos.x += (float)Math.Sin(i * 45) * dis;
            pos.y += (float)Math.Cos(i * 45) * dis;

            var pr_enemy = Instantiate(enemy, pos, Quaternion.identity, this.transform);
            pr_enemy.GetComponent<EnemyShip1>().MotherSpaceEnemy = this.motherSpaceEnemy;
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
            pr_Enemies[index].SetPostion();
            pr_Enemies[index].UpdateHealth();
            pr_Enemies[index].gameObject.SetActive(true);
            timeRate = 3;
            index = (index++) % poolSize;
        }
    }

    bool CheckInstance()
    {
        bool isInstance = false;
        Vector2 dis = this.transform.position - GameManager.instance.currentShip.transform.position;
        if (dis.magnitude < 30)
            isInstance = true;
        else isInstance = false;
        return isInstance;
    }
}
