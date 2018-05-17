using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxCanvas : MonoBehaviour {
    Quaternion iniRot;
    RectTransform rect;
    BoxCollider coll;
    PlayerPathMove move;

    public float XValue;
    private Vector3 initPosition;
    private Vector3 currentPosition;

    void Start()
    {
        iniRot = transform.rotation;
        rect = gameObject.GetComponent<RectTransform>();
        coll = gameObject.GetComponent<BoxCollider>();
        move = GameObject.Find("Player").GetComponent<PlayerPathMove>();

        initPosition = transform.position;
    }

    private void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.rotation = iniRot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Textbox")
        {
            initPosition.x = transform.position.x;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Textbox")
        {
            if (coll.bounds.max.x > other.transform.parent.position.x && transform.parent.position.x < other.transform.parent.position.x)
            {
                transform.position = initPosition;
            }
            else if (coll.bounds.min.x < other.transform.parent.position.x && transform.parent.position.x > other.transform.parent.position.x)
            {
                transform.position = initPosition;
            }

            if (transform.parent.position.x > other.transform.parent.position.x)
            {
                initPosition.x = transform.position.x + 0.5f;
            }
            else if (transform.parent.position.x < other.transform.parent.position.x)
            {
                initPosition.x = transform.position.x - 0.5f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Textbox")
        {
            transform.localPosition = new Vector3(0f, transform.localPosition.y, 0f);
        }
    }

    public void ChangeScale(Vector3 scale)
    {
        rect.localScale = scale;
    }

    public void ChangeSize(Vector2 size)
    {
        rect.sizeDelta = size;
    }

    public void ChangePosition(float x, float y, float z)
    {
        Vector3 position = new Vector3(x, y, z);
        rect.position = position;
    }
}
