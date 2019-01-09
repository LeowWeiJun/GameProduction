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
    public float speed = 2.0f;
    public Rigidbody2D rb;
    //private Vector2 velocity;
    public moveDirection Direction { set; get; }
    // Start is called before the first frame update

    //public InstantiateBrick instaScript;
    public GameObject test;
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
        
        
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
        {
            Direction = moveDirection.Left;
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
        {
            Direction = moveDirection.Right;
        }

        if(Direction == moveDirection.Down)
        {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
        }
        if(Direction == moveDirection.Left )
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }
        if(Direction == moveDirection.Right)
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
       if(collision.gameObject.name == "Boundary" && InstantiateBrick.Bricks[0].gameObject == gameObject)
        {
            //Debug.Log(InstantiateBrick.Bricks[0].gameObject);
            Destroy(InstantiateBrick.Bricks[0].gameObject);
            InstantiateBrick.Bricks.Remove(InstantiateBrick.Bricks[0]);
        }
    }

}
