using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
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

    public static readonly int WhiteChance = 35;
    public static readonly int BlackChance = 35;
    public static readonly int SkullChance = 30;
    public static readonly int TotalChance = WhiteChance + BlackChance + SkullChance;



    public GameObject whiteBrick;
    public GameObject blackBrick;
    public GameObject skullBrick;

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

    public static bool ReverseColor = false;
    // public static bool Touching = false;
    public GameObject progressBar;
    //public GameObject powerUP;
    private void Awake()
    {
        Life = initialLife;
        level = 1;
        completelevel = 0;
        levelStartDelay = 2.0f;
        InitGame();
    }
    void Start()
    {

        
        progressBar = GameObject.Find("ProgressBar");
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
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
        //Time.timeScale = 0f;
        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        //Debug.Log("HELLO WORLD");
        
        levelImage.SetActive(false);
        doingSetup = false;
        //Time.timeScale = 1f;
        StartCoroutine(SpawnBricks(spawnSpeed));
        StartCoroutine(Mistake());

    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Touching);
        if (doingSetup)
            return;

        if (GameObject.FindGameObjectWithTag("Brick") == null && counter == 0)
        {
            Debug.Log("NO BRICKS");
            completelevel++;
            OnLoadNewLevel();
        }
        //Debug.Log(Brick.isWrong);
        //Mistake();
        //if(Brick.isWrong == true)
        //{
        //    Brick.isWrong = false;
        //    instantiateBricks();
        //    instantiateBricks();
        //}


    }

    void OnLoadNewLevel()
    {
        if(level % 5 == 0)
        {
            PowerUPSelection.isSelect = true;
            //powerUP.SetActive(true);
            Time.timeScale = 0.0f;
            EventNo = Random.Range(0, 1);
            EventHandle(EventNo);

            
            //progressBar.SetActive(false);
            //progressBar.SetActive(true);
            //progressBar.GetComponent<ProgressBar>().enabled = false;
            //progressBar.GetComponent<ProgressBar>().enabled = true;
        }

        level++;
        counter = 10;
        InitGame();
    }
    public IEnumerator SpawnBricks(float waitTime)
    {

        Debug.Log(LevelManager.doingSetup);


        while (counter != 0)
        {
            //Debug.Log("Hello");
            //Debug.Log("Bam");
            yield return new WaitForSeconds(waitTime);

            instantiateBricks();
             //rb = GetComponent<Rigidbody2D>();
             //rb.MovePosition(rb.position + Vector2.down * Time.deltaTime);
             //Debug.Log(Bricks);
             //Debug.Log(Bricks[0]);
             //foreach(var human in Bricks)
             //{
             //    Debug.Log(human);
             //}
             counter--;
            //if(counter == 0)
               // yield return new WaitForSeconds(2.0f);
        }

        

        while (counter == 0 && LoseMenu.isLose != true)
        {
            

                //yield return new WaitForSeconds(20f);
                //instantiateBricks();

        }

        

    }

    public void instantiateBricks()
    {

         int x = Random.Range(0, TotalChance);

            if ((x -= WhiteChance) < 0)
            {
                brickClone = Instantiate(whiteBrick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            }
            else if ((x -= BlackChance) < 0)
            {
                brickClone = Instantiate(blackBrick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            }
            else
            {
                brickClone = Instantiate(skullBrick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            }
            //brickClone = Instantiate(brick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            ////Instantiate(BrickClone);

            //int x = Random.Range(0, 1);
            //brickClone.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
            Bricks.Add(brickClone);
    }

    public IEnumerator Mistake()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.15f);
            while (Brick.isWrong == true)
            {
                

                instantiateBricks();
                wrongCounter--;
                Debug.Log(wrongCounter);
                if (wrongCounter == 0)
                {
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

}
