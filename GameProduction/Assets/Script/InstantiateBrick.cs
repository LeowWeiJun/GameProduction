using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBrick : MonoBehaviour
{
    public GameObject bricks = null;
    public float moveSpeed = 5f;
    public float moveHoriz = 5f;
    //float directionY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(bricks, transform.position, Quaternion.identity);
        //rb = GetComponent<Rigidbody2D>();
        Instantiate(bricks, transform.position, Quaternion.identity);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.down * Time.deltaTime);


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
            rb.AddForce(Vector3.forward * 100f);
        }
        //Destroy(bricks);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
