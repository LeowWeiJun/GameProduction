using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSFX;
    private void Awake()
    {
        if(MenuStats.IsTutorial != -1)
            MenuStats.IsTutorial = 1;

        //Debug.Log(MenuStats.IsTutorial);
        SFXArr = Resources.LoadAll<Sprite>("SFX");
        BGMArr = Resources.LoadAll<Sprite>("BGM");
    }

    void Start()
    {
        //audioSourceBGM = GetComponent<AudioSource>();
        MenuStats.BgmVol = audioSourceBGM.volume;
        MenuStats.SfxVol = audioSourceSFX.volume;
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
        audioSourceSFX.volume = 100;
        if (SFXcount == SFXArr.Length)
        {
            SFXcount = 0;
            audioSourceSFX.volume = 0;
        }
        //Debug.Log(SFXcount);
        SFXImage.sprite = SFXArr[SFXcount];
        MenuStats.SfxVol = audioSourceSFX.volume;
    }

    public void BGMChanges()
    {
        BGMcount++;
        audioSourceBGM.volume = 100;
        if (BGMcount == BGMArr.Length)
        {
            BGMcount = 0;
            audioSourceBGM.volume = 0;
        }
        //Debug.Log(BGMcount);
        BGMImage.sprite = BGMArr[BGMcount];

        MenuStats.BgmVol = audioSourceBGM.volume;
        //Debug.Log(MenuStats.BgmVol);

    }
}
