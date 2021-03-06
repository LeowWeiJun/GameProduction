﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBrick : MonoBehaviour
{
    public static List<GameObject> Bricks;
    public static readonly int WhiteChance = 35;
    public static readonly int BlackChance = 35;
    public static readonly int SkullChance = 30;
    public static readonly int TotalChance = WhiteChance + BlackChance + SkullChance;



    public GameObject whiteBrick;
    public GameObject blackBrick;
    public GameObject skullBrick;
    public GameObject brick;
    private GameObject brickClone;
    public float spawnSpeed;
    //float directionY;
    Rigidbody2D rb;



    int counter = 10;
    Color[] colors = new Color[2];
    // Start is called before the first frame update
    void Start()
    {
        Bricks = new List<GameObject>();

        spawnSpeed = 0.15f;
        Debug.Log("Spawnspd : " + spawnSpeed);
        StartCoroutine(SpawnBricks(spawnSpeed));
        Debug.Log("Spawnspd : " + spawnSpeed);

        colors[0] = Color.white;
        colors[1] = Color.black;
        //Instantiate(bricks, transform.position, Quaternion.identity);
        //rb = GetComponent<Rigidbody2D>();
        //Instantiate(bricks,new Vector3(0,6,0), Quaternion.identity);
        //rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //SpawnBricks();

        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
        {
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 10f),transform.position.y , transform.position.z);
            //rb.velocity = new Vector2(rb.velocity.y, -moveHoriz);
            //Debug.Log("Left");
            //rb.AddForce(Vector3.forward * 100f);
            
            //transform.position = Vector3.Lerp(transform.position,5*transform.position , Time.deltaTime);
        }
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
        {
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 10f), transform.position.y, transform.position.z);
            //rb.velocity = new Vector2(rb.velocity.y, moveHoriz);
            //Debug.Log("Right");
            //rb.AddForce(Vector3.forward * 100f);
        }
        //Destroy(bricks);
    }
    // Update is called once per frame
    void Update()
    {
        

    }

    public IEnumerator SpawnBricks(float waitTime)
    {

        Debug.Log(LevelManager.doingSetup);
        

        if (counter != 0 )
        {
            

            Debug.Log("Hello");
            //Debug.Log("Bam");
            yield return new WaitForSeconds(waitTime);

            //Instantiate(BrickClone);
            int x = Random.Range(0, TotalChance);

            if ((x -= WhiteChance) < 0)
            {
                brickClone = Instantiate(brick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            }
            else if ((x -= BlackChance) < 0)
            {
                brickClone = Instantiate(brick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            }
            else
            {
                brickClone = Instantiate(brick, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
            }
            //int x = Random.Range(0, 1);
            //brickClone.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
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

}
