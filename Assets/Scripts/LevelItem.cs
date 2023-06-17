using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    [SerializeField] TMP_Text levelText;
    [SerializeField] Button selectLevelButton;

    private int level;

    private void Start()
    {
        selectLevelButton.interactable = PlayerPrefs.GetInt($"Level {level - 1} passed", 0) == 1;
    }


    public int Level
    {
        get { return level; }
        set { level = value; }
    }


    public void ChangeLevel()
    {
        GameManager.instance.ChangeLevel(Level);
    }

    public void SetLevelText(int i)
    {
        levelText.SetText(i.ToString());
    }
}
