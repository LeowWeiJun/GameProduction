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
    private bool dirDown = true;
    public float downSpeed = 2.0f;
    public float horizSpeed = 4.0f;
    public Rigidbody2D rb;
    //private Vector2 velocity;
    public moveDirection Direction { set; get; }
    // Start is called before the first frame update

    public GameObject brickParticle;
    public Color particleColor;
    private ParticleSystem ps;

    bool checkSwipe = false;
    
    //public InstantiateBrick instaScript;
    public GameObject test;

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
        

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + Vector2.down *speed* Time.deltaTime);
        //Debug.Log("Heh");
    }
    // Update is called once per frame
    void Update()
    {
       
        //if (dirDown)
        //  transform.Translate(Vector2.down * speed * Time.deltaTime);
        
        if(InstantiateBrick.Bricks[0].gameObject == gameObject && checkSwipe == false)
        {
            if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
            {
                Direction = moveDirection.Left;
                checkSwipe = true;
                //transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
            {
                Direction = moveDirection.Right;
                checkSwipe = true;
            }
        }
        

        if(Direction == moveDirection.Down || InstantiateBrick.Bricks[0].gameObject != gameObject)
        {
            rb.MovePosition(rb.position + Vector2.down * downSpeed * Time.deltaTime);
            
        }
        if(Direction == moveDirection.Left && InstantiateBrick.Bricks[0].gameObject == gameObject )
        {
            rb.MovePosition(rb.position + Vector2.left * horizSpeed * Time.deltaTime);
            
        }
        if(Direction == moveDirection.Right && InstantiateBrick.Bricks[0].gameObject == gameObject )
        {
            rb.MovePosition(rb.position + Vector2.right * horizSpeed * Time.deltaTime);
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.name == "Boundary" && InstantiateBrick.Bricks[0].gameObject == gameObject)
        {

            //Debug.Log(InstantiateBrick.Bricks[0].gameObject);
            Vector3 particlepos = transform.position;
            //particleColor = InstantiateBrick.Bricks[0].GetComponent<Renderer>().material.color;
            Destroy(InstantiateBrick.Bricks[0].gameObject);
            InstantiateBrick.Bricks.Remove(InstantiateBrick.Bricks[0]);

            GameObject bp = Instantiate(brickParticle, particlepos, Quaternion.identity) as GameObject;
            //particles.GetComponent<ParticleSystem>().startColor = particleColor;

            ParticleSystem ps = bp.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = gameObject.GetComponent<Renderer>().material.color;
        }
    }

    void brickParticles()
    {
        

    }

}
