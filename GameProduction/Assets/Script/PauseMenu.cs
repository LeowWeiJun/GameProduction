using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    public GameObject pauseMenuCanvas;
    // Start is called before the first frame update

    

    void Start()
    {
        isPaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            //Debug.Log("Paused");
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0.0f;
            //Debug.Log(Time.timeScale);
        }
        else if(isPaused != true && PowerUPSelection.isSelect != true)
        {
            //Debug.Log("UnPaused");
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1.0f;
            //Debug.Log(Time.timeScale);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
