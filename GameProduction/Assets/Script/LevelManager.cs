using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public List<int> number = new List<int>() { 1, 1, 1 };
    //public static int isTutorial;
    
    int y = 0;
    public GameObject HandSymbol;

    public GameObject swipeLeft;
    public GameObject swipeRight;
    public static bool swipeLeftActive = false;
    public static bool swipeRightActive = false;
    public GameObject Next;
    public GameObject Startbtn;
    public GameObject TutPanel;
    public GameObject TutStartPanel;


    public static AudioSource audioSourceSFX;
    public static AudioClip fallBrick;
    public static AudioClip skullBrick;
    public static AudioClip LoseTrack;
    public static AudioClip GameTrack;
    //public static AudioSource audiosourceSFX;
    public static AudioSource audioSource;
    public float levelStartDelay;
    
    public TextMeshProUGUI levelText;
    public GameObject levelImage;
    private int level;
    public static int completelevel;
    public static bool doingSetup;
    // Start is called before the first frame update


    public static int initialLife = 100;
    public static int Life;
    int EventNo;

    public static  int WhiteChance = 45;
    public static  int BlackChance = 45;
    public static  int whiteSkullChance = 5;
    public static  int blackSkullChance = 5;
    public static int whiteClockChance = 0;
    public static int blackClockChance = 0;
    public static  int TotalChance = WhiteChance + BlackChance + whiteSkullChance + blackSkullChance;


    public float distance;
    public GameObject whiteBrick;
    public GameObject blackBrick;
    public GameObject whiteSkullBrick;
    public GameObject blackSkullBrick;
    public GameObject whiteClockBrick;
    public GameObject blackClockBrick;

    public static List<GameObject> Bricks;
    //public GameObject brick;  
    private GameObject brickClone;
    public float spawnSpeed;
    //float directionY;
    Rigidbody2D rb;

    public static int initialBricks = 8;
    int counter;
    public static int wrongCounter = 0;
    Color[] colors = new Color[2];


    Coroutine spawner;
    Coroutine Mistakespawner;
    public static bool ReverseColor = false;
    // public static bool Touching = false;
    public GameObject progressBar;
    //public GameObject powerUP;
    private void Awake()
    {
        //if (MenuStats.IsTutorial == 1)
        //{
        //    Time.timeScale = 0;
        //    swipeLeft.SetActive(true);
        //}
        //else
        //{
            //TutPanel.SetActive(false);
            Life = initialLife;
            level = 0;
            completelevel = 0;
            levelStartDelay = 2.0f;
            InitGame();
            progressBar = GameObject.Find("ProgressBar");
        //}

        fallBrick = Resources.Load<AudioClip>("SFX/hero_land_soft");
        LoseTrack = Resources.Load<AudioClip>("BGM/Boss Defeat");
        skullBrick = Resources.Load<AudioClip>("SFX/focus_health_heal");
        GameTrack = Resources.Load<AudioClip>("BGM/Hollow Knight OST - City of Tears");

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = MenuStats.BgmVol;
        audioSource.clip = GameTrack;
        audioSource.Play();

        //Debug.Log(MenuStats.BgmVol);
        //Debug.Log(MenuStats.SfxVol);
        audioSourceSFX = GetComponent<AudioSource>();
        audioSourceSFX.volume = MenuStats.SfxVol;
        //Life = initialLife;
        //level = 1;
        //completelevel = 0;
        //levelStartDelay = 2.0f;
        //InitGame();

    }
    void Start()
    {
        
        

        

        //audiosourceSFX.volume = MenuStats.SfxVol;
        
        //HandSymbol = GameObject.Find("HandSwipe");
        Bricks = new List<GameObject>();
        spawnSpeed = 0.15f;
        colors[0] = Color.white;
        colors[1] = Color.black;
    }

    

    //private void OnLevelWasLoaded(int level)
    //{
    //    level++;
    //    InitGame();
    //}

    void InitGame()
    {
        progressBar.SetActive(true);
        counter = initialBricks;
        doingSetup = true;
        //levelImage = GameObject.Find("LevelImage");
        //levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        if(MenuStats.IsTutorial == -1)
        {
            levelText.text = "Level " + level;
            levelImage.SetActive(true);
        }
        
        
        //Time.timeScale = 0f;
        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        //Debug.Log("HELLO WORLD");
        if (MenuStats.IsTutorial == -1)
        {
            levelImage.SetActive(false);
        }
            
        doingSetup = false;
        //Time.timeScale = 1f;
        spawner = StartCoroutine(SpawnBricks(spawnSpeed));
        Mistakespawner = StartCoroutine(Mistake());

    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Touching);
        if ((doingSetup || MenuStats.IsTutorial == 1) && GameObject.FindGameObjectWithTag("Brick") != null)
            return;

        if (GameObject.FindGameObjectWithTag("Brick") == null && counter == 0 && wrongCounter <= 0)
        {

            if (MenuStats.IsTutorial == 1)
            {
                TutStartPanel.SetActive(true);
                Time.timeScale = 0;
            }
               // MenuStats.IsTutorial = -1;
            wrongCounter = 0;
            StopCoroutine(spawner);
            StopCoroutine(Mistakespawner);
            Debug.Log("NO BRICKS");
            completelevel++;
            OnLoadNewLevel();
        }

    }

    void OnLoadNewLevel()
    {
        if(level% 2 == 0)
        {
            whiteSkullChance += 2;
            blackSkullChance += 2;
        }
        if(level % 5 == 0)
        {
            //PowerUPSelection.isSelect = true;
            //powerUP.SetActive(true);
            //Time.timeScale = 0.0f;
            EventNo = Random.Range(0, 1);
            EventHandle(EventNo);

            initialBricks += 1;

        }
        ProgressBar.ResetTime();
        level++;

        InitGame();
    }
    public IEnumerator SpawnBricks(float waitTime)
    {

        //Debug.Log(LevelManager.doingSetup);


        while (counter != 0)
        {

            yield return new WaitForSeconds(waitTime);

            instantiateBricks();

             counter--;

        }

        Debug.Log(counter);
        Debug.Log(MenuStats.IsTutorial);

        while (counter == 0 && MenuStats.IsTutorial == 1)
        {
            if (swipeLeftActive == true && swipeRightActive == true)
                break;
            if(Bricks[0].GetComponent<Renderer>().material.color == Color.white && swipeLeftActive == false)
            {
                swipeLeft.SetActive(true);
                swipeLeftActive = true;

                yield return new WaitForSeconds(1.0f);
            }
            else if(Bricks[0].GetComponent<Renderer>().material.color == Color.black && swipeRightActive == false)
            {
                swipeRight.SetActive(true);
                swipeRightActive = true;
                yield return new WaitForSeconds(2.0f);
            }
            yield return new WaitForFixedUpdate();


        }

        while (counter == 0 && LoseMenu.isLose != true && doingSetup == false && MenuStats.IsTutorial == -1)
        {
            

                yield return new WaitForSeconds(2f);
                instantiateBricks();

        }

        

    }


    public void instantiateBricks()
    {
        if (Bricks != null || Bricks.Count == 1)
        {
            distance = 6;
        }
        else
        {
            distance = (Bricks.Count - 2) * 0.5f + 6;
        }
         int x = Random.Range(0, TotalChance);

            if ((x -= WhiteChance) < 0)
            {
                brickClone = Instantiate(whiteBrick, new Vector3(0, distance, -1), Quaternion.identity) as GameObject;
            }
            else if ((x -= BlackChance) < 0)
            {
                brickClone = Instantiate(blackBrick, new Vector3(0, distance, -1), Quaternion.identity) as GameObject;
            }
            else if((x-= whiteSkullChance)< 0)
            {
                brickClone = Instantiate(whiteSkullBrick, new Vector3(0, distance, -1), Quaternion.identity) as GameObject;
            }
            else
            {
                brickClone = Instantiate(blackSkullBrick, new Vector3(0, distance, -1), Quaternion.identity) as GameObject;
            }
        Bricks.Add(brickClone);
    }

    public IEnumerator Mistake()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.15f);
            while (Brick.isWrong == true && wrongCounter > 0)
            {

                yield return new WaitForSeconds(0.15f);
                instantiateBricks();
                wrongCounter--;
                //Debug.Log(wrongCounter);
                if (wrongCounter <= 0)
                {
                    wrongCounter = 0;
                    Brick.isWrong = false;

                }
            }
            
        }
    }

    public void EventHandle(int EventNo)
    {
        if(EventNo == 0)
        {
            initialBricks++;
        }
    }

    public void NextTut()
    {
        TutStartPanel.SetActive(false);
        InitGame();
    }

    public void StartPlay()
    {
        TutStartPanel.SetActive(false);

        MenuStats.IsTutorial = -1;

        Life = initialLife;
        level = 1;
        completelevel = 0;
        levelStartDelay = 2.0f;
        InitGame();
        progressBar = GameObject.Find("ProgressBar");
    }

    public void PauseGame()
    {
        PauseMenu.isPaused = true;
    }
}
