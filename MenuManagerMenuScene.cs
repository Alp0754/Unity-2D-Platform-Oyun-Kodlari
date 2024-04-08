using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dataBoard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.instance.LoadData();
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Bullet Shot:" + DataManager.instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed:" + DataManager.instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }

    public void Xbutton()
    {
        dataBoard.SetActive(false);
    }
}
