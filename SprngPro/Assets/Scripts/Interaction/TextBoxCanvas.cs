using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxCanvas : MonoBehaviour {
    Quaternion iniRot;
    RectTransform rect;
    BoxCollider coll;

    public float XValue;
    private Vector3 initPosition;
    private Vector3 currentPosition;

    void Start()
    {
        iniRot = transform.rotation;
        rect = gameObject.GetComponent<RectTransform>();
        coll = gameObject.GetComponent<BoxCollider>();

        initPosition = transform.position;
    }

    private void Update()
    {
        Debug.Log(transform.parent.position.x);
        if (transform.parent.position.x > initPosition.x)
        {
            Debug.Log("hee");
        }

        if (transform.parent.position.x > transform.parent.position.x)
        {
            transform.position = transform.position;
        }
    }

    void LateUpdate()
    {
        transform.rotation = iniRot;
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
