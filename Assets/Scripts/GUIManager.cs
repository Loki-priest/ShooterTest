using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Text healthTxt;
    public Text scoreTxt;

    public GameObject losePopup;
    public GameObject winPopup;

    public Button loseRestart;
    public Button winRestart;

    bool gameOverShowed = false;

    private void Awake()
    {
        loseRestart.onClick.AddListener(Restart);
        winRestart.onClick.AddListener(Restart);
    }

    void Restart() //load scene again
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public void ShowHealth(int health)
    {
        healthTxt.text = health.ToString();
    }

    public void ShowScore(int score)
    {
        scoreTxt.text = score.ToString();
    }


    public void ShowGameOver(bool isWin)
    {
        if (gameOverShowed)
            return;

        if (isWin)
            ShowWin();
        else
            ShowLose();

        gameOverShowed = true;
    }


    void ShowLose()
    {
        losePopup.SetActive(true);
    }

    void ShowWin()
    {
        winPopup.SetActive(true);
    }



}
