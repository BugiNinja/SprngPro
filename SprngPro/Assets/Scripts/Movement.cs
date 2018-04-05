using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

	void Start () {

        walkSpeed = 3;
        runSpeed = 6;
        moveSpeed = walkSpeed;
	}
	
	void Update ()
    {
        Move();
        SwitchBackAndForthBetweenWalkAndRun();
	}

    void SwitchBackAndForthBetweenWalkAndRun()
    {
        if(Input.GetKeyDown(KeyCode.R) && moveSpeed != runSpeed)
        {
            moveSpeed = runSpeed;
        }
        else if(Input.GetKeyDown(KeyCode.R) && moveSpeed != walkSpeed)
        {
            moveSpeed = walkSpeed;
        }
    }

    void Move()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
    }
}
