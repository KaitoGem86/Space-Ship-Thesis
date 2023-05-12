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

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

}
