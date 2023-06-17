using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : BasePanel
{
    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }
}
