using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerIngame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inGameScreen, PauseScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PouseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        PauseScreen.SetActive(false);

    }

    public void ReplayButton()

    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.instance.SaveData();
        SceneManager.LoadScene(0);
    }
}
