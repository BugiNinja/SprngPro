using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxCanvas : MonoBehaviour {
    Quaternion iniRot;
    RectTransform rect;

    /*public Vector3 Position;
    public Vector3 Scale;
    public Vector2 Size;*/

    private bool isCollided;

    void Start()
    {
        iniRot = transform.rotation;
        rect = gameObject.GetComponent<RectTransform>();

        /*Scale = rect.localScale;
        Position = rect.position;
        Size = rect.sizeDelta;*/

        isCollided = false;
    }

    private void Update()
    {
        /*RestrictScale();
        RestrictSize();*/
    }

    void LateUpdate()
    {
        transform.rotation = iniRot;
    }

    /*private void RestrictScale()
    {
        if (Scale.x < 0)
        {
            Scale.x = 0;
        }
        if (Scale.y < 0)
        {
            Scale.y = 0;
        }
        if (Scale.z != 0)
        {
            Scale.z = 0;
        }

        if (Scale.x > 1)
        {
            Scale.x = 1;
        }
        if (Scale.y > 1)
        {
            Scale.y = 1;
        }
    }

    private void RestrictSize()
    {
        if (Size.x < 0)
        {
            Size.x = 0;
        }
        if (Size.y < 0)
        {
            Size.y = 0;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Textbox")
        {
            isCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Textbox")
        {
            isCollided = false;
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

    public void ChangePosition(Vector3 position)
    {
        rect.position = position;
    }
}
