using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int exitCount;
    // Start is called before the first frame update
    void Start()
    {
        exitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            exitCount++;
            if (!IsInvoking("disableDoubleClick"))
                Invoke("disableDoubleClick", 0.3f);
        }
        if (exitCount == 2)
        {
            CancelInvoke("disableDoubleClick");
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void disableDoubleClick()
    {
        exitCount = 0;
    }
}
