using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController currentShip;
    public MotherSpaceEnemy motherSpaceEnemy;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        InvokeRepeating("UpdateAstar", 0, 0.5f);
    }

    void    UpdateAstar()
    {
        AstarPath.active.Scan();
    }

    public void GameOver()
    {
        currentShip.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

}
