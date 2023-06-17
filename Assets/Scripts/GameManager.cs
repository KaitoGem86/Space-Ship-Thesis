using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController currentShip;
    public MotherSpaceEnemy motherSpaceEnemy;
    public int point;
    public bool isWin;
    public int currentLevel;
    public LevelData levelData;

    private void Awake()
    {
        instance = this;
        PlayerPrefs.SetInt($"Level {currentLevel} passed", 1);
    }

    public void Start()
    {
        InvokeRepeating("UpdateAstar", 0, 0.5f);
        point = 0;
    }

    void UpdateAstar()
    {
        AstarPath.active.Scan();
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
        currentShip.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        isWin = true;
        PlayerPrefs.SetInt($"Level {currentLevel} passed", 1);
        PlayerPrefs.SetInt($"Level {currentLevel + 1} passed", 1);
        PlayerPrefs.SetInt("Current Level", currentLevel + 1 >= levelData.data.Count ? levelData.data.Count : currentLevel + 1);
        this.currentShip.PlayerWinGame();
    }

    public void ChangeLevel(int i)
    {
        PlayerPrefs.SetInt("Current Level", i - 1);
        SceneManager.LoadScene("GameScene");
    }
}
