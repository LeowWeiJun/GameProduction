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
    //public InstantiateBrick instaScript;
    public GameObject test;


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
        //instaScript = GetComponent<InstantiateBrick>();
        brickColor = gameObject.GetComponent<Renderer>().material.color; // check whether white or black
        downSpeed = 30.0f;
        horizSpeed = 15.0f;
        isSwipe = false;
        isFirst = false;

    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.Scale(rb.velocity, new Vector3(1, 1 - damp, 1));
        //rb.MovePosition(rb.position + Vector2.down *speed* Time.deltaTime);
        //Debug.Log("Heh");
        //var currentVelocity = rb.velocity;

        //if (currentVelocity.y <= 0f)
        //    return;

        //currentVelocity.y = 0f;

        //rb.velocity = currentVelocity;
        if (isSwipe == true && InstantiateBrick.Bricks.Count > 0 && InstantiateBrick.Bricks[0].gameObject == gameObject)
        {
            InstantiateBrick.Bricks.Remove(InstantiateBrick.Bricks[0]);
            isFirst = true;
            SwipeManager.Instance.Direction = SwipeDirection.None;
        }

        if (Direction == moveDirection.Down || isFirst != true)//InstantiateBrick.Bricks[0].gameObject != gameObject)
        {
            rb.MovePosition(rb.position + Vector2.down * downSpeed * Time.fixedDeltaTime);

        }
        else if (Direction == moveDirection.Left && isFirst == true)//InstantiateBrick.Bricks[0].gameObject == gameObject)
        {
            //rb.AddTorque(50.0f);
            rb.MovePosition(rb.position + Vector2.left * horizSpeed * Time.fixedDeltaTime);
            //rb.MoveRotation(rb.rotation + 50.0f * Time.fixedDeltaTime);

        }
        else if (Direction == moveDirection.Right && isFirst == true)//InstantiateBrick.Bricks[0].gameObject == gameObject)
        {
            rb.MovePosition(rb.position + Vector2.right * horizSpeed * Time.fixedDeltaTime);

        }

        
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("List Size : " + InstantiateBrick.Bricks.Count);

        //if (dirDown)
        //  transform.Translate(Vector2.down * speed * Time.deltaTime);




        if (InstantiateBrick.Bricks.Count > 0 && InstantiateBrick.Bricks[0].gameObject == gameObject && isSwipe == false)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        rb.velocity = new Vector3(0, 0,0);
        if (collision.gameObject.name == "Boundary" && isFirst == true)
        {
            Debug.Log("Collided");
            //Debug.Log(InstantiateBrick.Bricks[0].gameObject);
            Vector3 particlepos = transform.position;
            //particleColor = InstantiateBrick.Bricks[0].GetComponent<Renderer>().material.color;
            Destroy(gameObject);
            //InstantiateBrick.Bricks.Remove(InstantiateBrick.Bricks[0]);

            GameObject bp = Instantiate(brickParticle, particlepos, Quaternion.identity) as GameObject;
            //particles.GetComponent<ParticleSystem>().startColor = particleColor;

            ParticleSystem ps = bp.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = brickColor;

            if(Direction == moveDirection.Left && brickColor != Color.white || Direction == moveDirection.Right && brickColor != Color.black)
            {
                psmain.startColor = Color.red;
            }
            else
            {
                Score.scoreValue++;
            }

            
        }
    }

    //void CheckFirst()
    //{
        
    //}


}
