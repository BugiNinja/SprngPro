﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamicamera : MonoBehaviour {

    GameObject player;
    Camera c;
    GameObject Background;
    private Vector3 offset;
    float backgroundmin;
    float backgroundmax;
    float newPositionX;
    public float MaxSize = 7;
    public float MinSize = 3;
    public float ScaleSpeed = 0.05f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Background = GameObject.FindGameObjectWithTag("Background");
        c = gameObject.GetComponent<Camera>();
        offset = transform.position - player.transform.position;
        backgroundmin = Background.GetComponent<Renderer>().bounds.min.x;
        backgroundmax = Background.GetComponent<Renderer>().bounds.max.x;
    }


    void Update()
    {
        newPositionX = player.transform.position.x + offset.x;

        if (InBounds())
        {
            //ScaleSize();
            transform.position = player.transform.position + offset;
        }


    }
    bool InBounds()
    {
        if (transform.position.x - (c.orthographicSize * 2 * c.aspect / 2) - (transform.position.x - newPositionX) <= backgroundmin || transform.position.x + (c.orthographicSize * 2 * c.aspect / 2) + (newPositionX - transform.position.x) >= backgroundmax)
        {
            return false;
        }
        else
        {

            return true;
        }
    }
    void ScaleSize()
    {
        if (newPositionX != transform.position.x)
        {
            if (c.orthographicSize < MaxSize)
            {
                c.orthographicSize += ScaleSpeed;
            }
        }
        else
        {
            if (c.orthographicSize > MinSize)
            {
                c.orthographicSize -= ScaleSpeed;
            }
        }
    }
}