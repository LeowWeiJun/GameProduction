using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public static bool isLose;
    public GameObject loseMenuCanvas;
    // Start is called before the first frame update



    void Start()
    {
        isLose = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isLose)
        {
            loseMenuCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
       

        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    isLose = !isLose;
        //}
        if(MenuStats.IsTutorial == -1 && (ProgressBar.isTimeUp == true || LevelManager.Life == 0))
        {
            isLose = true;
            LevelManager.audioSource.clip = LevelManager.LoseTrack;
        }
    }

    public void ResetGame()
    {
        LevelManager.Life = 1;
        LevelManager.initialBricks = 8; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
