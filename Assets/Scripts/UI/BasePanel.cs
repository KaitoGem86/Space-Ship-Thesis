using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasePanel : MonoBehaviour
{
    [SerializeField] GameObject levelList;

    public void ToLevelList()
    {
        Time.timeScale = 0f;
        GameManager.instance.currentShip.gameObject.SetActive(false);
        levelList.SetActive(true);
    }

    public void ToSelectShipList()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartScene");
    }


}
