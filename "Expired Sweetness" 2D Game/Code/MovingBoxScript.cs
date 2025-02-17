﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoxScript : MonoBehaviour
{

    public GameObject lwP, rwP;

    public float moveSpeed = 0.3f;
    Transform leftWayPoint, rightWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;

    void Start()  {

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
        leftWayPoint = lwP.GetComponent<Transform> ();
        rightWayPoint = rwP.GetComponent<Transform> ();

    }

    void Update() {

        if (transform.position.x > rightWayPoint.position.x)
            movingRight = false;
        if (transform.position.x < leftWayPoint.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();
    }

    void moveRight() {
        movingRight = true;

        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2 (localScale.x * moveSpeed, rb.velocity.y);
    }

    void moveLeft() {
        
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2 (localScale.x * moveSpeed, rb.velocity.y);
    }


} // class
