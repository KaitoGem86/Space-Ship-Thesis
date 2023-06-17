using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyPool : MonoBehaviour
{
    [SerializeField] BaseEnemy bossEnemy;

    BaseEnemy boss;
    int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.num = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
