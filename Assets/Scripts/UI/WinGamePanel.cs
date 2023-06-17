using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGamePanel : BasePanel
{
    [SerializeField] GameObject nextLevelText;
    public void TapToNextLevel()
    {
        GameManager.instance.currentLevel += 1;
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
