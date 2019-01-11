using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSelection : MonoBehaviour
{
    public static bool isSelect;
    public GameObject PowerupsSelectCanvas;
    // Start is called before the first frame update



    void Start()
    {
        isSelect = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelect)
        {
            PowerupsSelectCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }


        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    isLose = !isLose;
        //}
        //if (LevelManager.completelevel % 5 == 0 && LevelManager.completelevel != 0)
        //{
        //    isSelect = true;
        //    LevelManager.completelevel = 0;
        //}
    }

    public void IncreaseMaxTime()
    {
        Debug.Log("Clicked");
        isSelect = false;
        ProgressBar.initialTime += 1;
        PowerupsSelectCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        ProgressBar.ResetTime();
    }

    public void IncreaseLife()
    {
        Debug.Log("Clicked");
        isSelect = false;
        LevelManager.Life++;
        PowerupsSelectCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
