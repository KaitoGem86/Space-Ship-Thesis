using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingEnemyPool : EnemyPool
{
    [SerializeField] BaseEnemy movingEnemy;
    [SerializeField] float distance;

    private BaseEnemy[] enemyPool;
    private int numOfE;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyPool();
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos += direction * Time.deltaTime;
        this.transform.position = pos;
    }

    void SetEnemyPool()
    {
        var size = movingEnemy.GetComponent<SpriteRenderer>().size;
        numOfE = UnityEngine.Random.Range(3, 4);
        enemyPool = new BaseEnemy[numOfE];
        this.num = numOfE;
        for (int i = 0; i < numOfE; i++)
        {
            Vector2 pos = new Vector2();
            pos.x = i * size.x / 2 + distance;
            var go = Instantiate(movingEnemy.gameObject, pos, Quaternion.identity, this.transform);
            enemyPool[i] = go.GetComponent<BaseEnemy>();
            enemyPool[i].Pool = this;
        }
    }

    public override void SetPosition()
    {
        int i = UnityEngine.Random.Range(0, 1);
        i = 0;
        if (i == 0)
        {
            this.transform.position = new Vector3(5, 5, 0);
            direction = Vector3.left;
        }
        else
        {
            this.transform.position = new Vector3(-5, 5, 0);
            direction = Vector3.right;
        }
    }

    public override void SetEnemy()
    {
        this.num = numOfE;
        foreach (var go in enemyPool)
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
