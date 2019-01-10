using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int exitCount;
    // Start is called before the first frame update

    public Sprite[] SFXArr;
    public Image SFXImage;
    int SFXcount;

    public Sprite[] BGMArr;
    public Image BGMImage;
    int BGMcount;
    private void Awake()
    {
        SFXArr = Resources.LoadAll<Sprite>("SFX");
        BGMArr = Resources.LoadAll<Sprite>("BGM");
    }

    void Start()
    {
        exitCount = 0;
        SFXcount = 1;
        BGMcount = 1;
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

    public void SFXChanges()
    {
        SFXcount++;

        if (SFXcount == SFXArr.Length)
        {
            SFXcount = 0;
        }
        //Debug.Log(SFXcount);
        SFXImage.sprite = SFXArr[SFXcount];

    }

    public void BGMChanges()
    {
        BGMcount++;

        if (BGMcount == BGMArr.Length)
        {
            BGMcount = 0;
        }
        //Debug.Log(BGMcount);
        BGMImage.sprite = BGMArr[BGMcount];

    }
}
