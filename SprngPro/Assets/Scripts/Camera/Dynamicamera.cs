using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamicamera : MonoBehaviour {

    private GameObject player;
    private Camera c;
    private GameObject background;
    public Vector3 offset;
    private float backgroundmin;
    private float backgroundmax;
    private float newPositionX;

    public float MaxSize = 7;
    public float MinSize = 3;
    public float ScaleSpeed = 0.05f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.FindGameObjectWithTag("Background");
        if(background == null)
        {
            Debug.LogWarning("missing background bound!");
        }
        if(player == null)
        {
            Debug.LogWarning("player is missing or don't have player tag!");
        }
        c = gameObject.GetComponent<Camera>();
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, 2, -10);
        backgroundmin = background.GetComponent<Renderer>().bounds.min.x;
        backgroundmax = background.GetComponent<Renderer>().bounds.max.x;
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
