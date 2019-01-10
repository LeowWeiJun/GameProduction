using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1.0f;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
}
