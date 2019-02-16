
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static List<GameObject> Bricks;
    

    int x = 0;
    public GameObject whiteBrick;
    public GameObject blackBrick;
    public GameObject skullBrick;
    //public GameObject brick;
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
        //StartCoroutine(SpawnBricks(spawnSpeed));

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

    //public IEnumerator SpawnBricks(float waitTime)
    //{

    //    Debug.Log(LevelManager.doingSetup);
        

        
    //}

}
