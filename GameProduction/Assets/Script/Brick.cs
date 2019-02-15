using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum moveDirection
{
    None,
    Left,
    Right,
    Up,
    Down,
}

public class Brick : MonoBehaviour
{
    //private bool dirDown = true;
    public float downSpeed;
    public float horizSpeed;
    //Vector2 velocity2 = new Vector2(30f,30f);
    public Rigidbody2D rb;
    //private Vector2 velocity;
    public moveDirection Direction { set; get; }
    // Start is called before the first frame update

    public GameObject brickParticle;
    public Color brickColor;
    private ParticleSystem ps;

    bool isSwipe;
    bool isFirst;
    //public LevelManager instaScript;
    public GameObject test;

    public static bool isWrong = false; 
    float damp = 0.1f;

    

    private void Awake()
    {
        //ps = test.GetComponent<ParticleSystem>();
        //ParticleSystem.MainModule main = ps.main;
        //main.startColor = gameObject.GetComponent<Renderer>().material.color;

    }
    void Start()
    {
      //  velocity = new Vector2(1.75f, 1.1f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        Direction = moveDirection.Down;
        //instaScript = GetComponent<LevelManager>();
        brickColor = gameObject.GetComponent<Renderer>().material.color; // check whether white or black
        downSpeed = 30.0f;
        horizSpeed = 15.0f;
        isSwipe = false;
        isFirst = false;

    }

    void FixedUpdate()
    {
        //if(rb.bodyType != RigidbodyType2D.Static)
        rb.velocity = Vector3.Scale(rb.velocity, new Vector3(1, 1 - damp, 1));
        //rb.MovePosition(rb.position + Vector2.down *speed* Time.deltaTime);
        //Debug.Log("Heh");
        //var currentVelocity = rb.velocity;

        //if (currentVelocity.y <= 0f)
        //    return;

        //currentVelocity.y = 0f;
        
        //rb.velocity = currentVelocity;
        if (isSwipe == true && LevelManager.Bricks.Count > 0 && LevelManager.Bricks[0].gameObject == gameObject)
        {
            LevelManager.Bricks.Remove(LevelManager.Bricks[0]);
            isFirst = true;
            SwipeManager.Instance.Direction = SwipeDirection.None;
        }

        //if (isFirst == true)
        //{
        //    Debug.Log(rb.bodyType);
        //    rb.bodyType = RigidbodyType2D.Dynamic;
        //    Debug.Log(rb.bodyType);
        //}
            

        if (Direction == moveDirection.Down || isFirst != true)//LevelManager.Bricks[0].gameObject != gameObject)
        {
            rb.MovePosition(rb.position + Vector2.down * downSpeed * Time.fixedDeltaTime);

        }
        else if (Direction == moveDirection.Left && isFirst == true)//LevelManager.Bricks[0].gameObject == gameObject)
        {
            //rb.AddTorque(50.0f);
            rb.MovePosition(rb.position + Vector2.left * horizSpeed * Time.fixedDeltaTime);
            //rb.MoveRotation(rb.rotation + 50.0f * Time.fixedDeltaTime);
            //LevelManager.Touching = false;

        }
        else if (Direction == moveDirection.Right && isFirst == true)//LevelManager.Bricks[0].gameObject == gameObject)
        {
            rb.MovePosition(rb.position + Vector2.right * horizSpeed * Time.fixedDeltaTime);
            //LevelManager.Touching = false;

        }

        
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("List Size : " + LevelManager.Bricks.Count);

        //if (dirDown)
        //  transform.Translate(Vector2.down * speed * Time.deltaTime);


        //if (rb.velocity.y <= 0.0f)
        //{
        //    rb.Sleep();
        //}

        if (LevelManager.Bricks.Count > 0 && LevelManager.Bricks[0].gameObject == gameObject && isSwipe == false)
        {
            if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
            {
                Direction = moveDirection.Left;
                isSwipe = true;
                //CheckFirst();
                //transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
            {
                Direction = moveDirection.Right;
                isSwipe = true;
                //CheckFirst();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //rb.velocity = new Vector3(0, 0,0);
        if (collision.gameObject.name == "Boundary" && isFirst == true)
        {
           // LevelManager.Touching = true;
            //rb.bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("Collided");
            //Debug.Log(LevelManager.Bricks[0].gameObject);
            Vector3 particlepos = transform.position;
            //particleColor = LevelManager.Bricks[0].GetComponent<Renderer>().material.color;
            Destroy(gameObject);
            //LevelManager.Bricks.Remove(LevelManager.Bricks[0]);

            GameObject bp = Instantiate(brickParticle, particlepos, Quaternion.identity) as GameObject;
            //particles.GetComponent<ParticleSystem>().startColor = particleColor;

            ParticleSystem ps = bp.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = brickColor;

            if(Direction == moveDirection.Left && brickColor != Color.white || Direction == moveDirection.Right && brickColor != Color.black)
            {
                psmain.startColor = Color.red;
                isWrong = true;
                
                LevelManager.wrongCounter += 2;
                LevelManager.Life--;
                //LevelManager.Touching = false;
            }
            else
            {
                Score.scoreValue++;
                //LevelManager.Touching = false;
            }

            //if (collision.gameObject.tag == "Brick")
            //{
            //    Debug.Log("XXX");
            //    //rb.velocity = new Vector3(0, 0, 0);
            //    rb.bodyType = RigidbodyType2D.Static;
            //}
        }
        
        //if (collision.gameObject.tag == "Brick" && LevelManager.Touching == true && isFirst!= true)
        //{
        //    //Debug.Log("XXX");
        //    //rb.velocity = new Vector3(0, 0, 0);
        //    rb.bodyType = RigidbodyType2D.Static;
        //}
        //else
        //{
        //    rb.bodyType = RigidbodyType2D.Dynamic;
        //}


    }

    //void CheckFirst()
    //{
        
    //}


}
