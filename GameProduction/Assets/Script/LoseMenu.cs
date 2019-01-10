using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    bool isLose;
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
        else
        {
            loseMenuCanvas.SetActive(false);
            Time.timeScale = 1.0f;
        }

        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    isLose = !isLose;
        //}
        if(ProgressBar.isTimeUp == true)
        {
            isLose = true;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
