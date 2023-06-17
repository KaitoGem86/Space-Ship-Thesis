using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    [SerializeField] private TMP_Text pointText;
    [SerializeField] private Image health;
    [SerializeField] GameObject winGamePanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject gameOverPanel;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        winGamePanel.SetActive(false);
        levelPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePoint(int point)
    {
        pointText.SetText($"POINTS: {point}");
    }

    public void UpdateHp(float hp, float maxHp)
    {
        health.fillAmount = hp / maxHp;
    }

    public void WinGame()
    {
        winGamePanel.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
