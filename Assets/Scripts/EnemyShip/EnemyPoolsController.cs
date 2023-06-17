using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolsController : MonoBehaviour
{
    [SerializeField] List<EnemyPool> enemyPools = new List<EnemyPool>();

    List<int> index;
    int i = 0;

    EnemyPool currentPool = null;
    // Start is called before the first frame update
    void Start()
    {
        SetLevel();
        i = 0;
        for (int i = 0; i < enemyPools.Count; i++)
            enemyPools[i].gameObject.SetActive(false);
        SetPoolActive();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentPool.gameObject.activeSelf)
        {
            i = i + 1;
            Debug.Log(i);
            if (i > index.Count)
            {
                i = index.Count;
                GameManager.instance.WinGame();
                return;
            }
            SetPoolActive();
        }
    }

    void SetPoolActive()
    {
        currentPool = enemyPools[index[i]];
        currentPool.gameObject.SetActive(true);
        currentPool.SetEnemy();
        currentPool.SetPosition();
    }

    void SetLevel()
    {
        GameManager.instance.currentLevel = PlayerPrefs.GetInt("Current Level", 0) - 1 < 0 ? 0 : PlayerPrefs.GetInt("Current Level", 0) - 1;
        this.index = GameManager.instance.levelData.data[GameManager.instance.currentLevel].listIndex;
    }
}
