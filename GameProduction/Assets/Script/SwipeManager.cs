﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,
}
public class SwipeManager : MonoBehaviour
{
    private static SwipeManager instance;
    public static SwipeManager Instance{get{return instance;}}
    public SwipeDirection Direction { set; get; }
    private Vector3 touchPosition;
    private float swipeResistanceX = 50.0f;
    //private float swipeResistanceY = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        Direction = SwipeDirection.None;
        //Debug.Log("Direction : " + Direction);
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
            {
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
                Input.ResetInputAxes();
            }



        }
    }

    public bool IsSwiping(SwipeDirection dir)
    {
        return (dir == Direction);
    }
}
