﻿using System.Collections;
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


    public static int Life = 1;
    int EventNo;


    public static List<GameObject> Bricks;
    public GameObject brick;  
    private GameObject brickClone;
    public float spawnSpeed;
    //float directionY;
    Rigidbody2D rb;

    static int initialBricks = 1;
    int counter;
    Color[] colors = new Color[2];


    public GameObject progressBar;

    private void Awake()
    {
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

    }

    // Update is called once per frame
    void Update()
    {
        if (doingSetup)
            return;

        if (GameObject.FindGameObjectWithTag("Brick") == null && counter == 0)
        {
            Debug.Log("NO BRICKS");
            completelevel++;
            OnLoadNewLevel();
        }
            

    }

    void OnLoadNewLevel()
    {
        if(level % 5 == 0)
        {
            EventNo = Random.Range(0, 1);
            EventHandle(EventNo);

            ProgressBar.ResetTime();
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
            Debug.Log("Hello");
            //Debug.Log("Bam");
            yield return new WaitForSeconds(waitTime);
            brickClone = Instantiate(brick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            //Instantiate(BrickClone);

            int x = Random.Range(0, 1);
            brickClone.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
            Bricks.Add(brickClone);
            //rb = GetComponent<Rigidbody2D>();
            //rb.MovePosition(rb.position + Vector2.down * Time.deltaTime);
            //Debug.Log(Bricks);
            //Debug.Log(Bricks[0]);
            //foreach(var human in Bricks)
            //{
            //    Debug.Log(human);
            //}
            counter--;

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
