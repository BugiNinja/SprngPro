using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathMove : MonoBehaviour {

    public int SpawnNodeId = 0;
    public float WalkSpeed = 20;

    private string pathName = "PlayerPath";
    private EditorPath pathToFollow;

    private bool enabledMove = true;

    private int currentWayPointId = 0;
    private int lastWayPointId = 0;

    private int moveDirection = 1; //1 = forward, -1 = backward 
    private float moveSpeed = 0;
    private float reachDistance = 1f;

    

    private void Start()
    {
        pathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        currentWayPointId = SpawnNodeId;
        lastWayPointId = SpawnNodeId - 1;
        transform.position = pathToFollow.Nodes[currentWayPointId].position;
    }

    private void Update()
    {
        CheckMovement();
        float distance = Vector3.Distance(pathToFollow.Nodes[currentWayPointId].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.Nodes[currentWayPointId].position, Time.deltaTime * moveSpeed);

        if (distance <= reachDistance)
        {
            
            lastWayPointId = currentWayPointId;
            currentWayPointId += moveDirection;

        }
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.A) && enabledMove)
        {
            if(currentWayPointId > lastWayPointId)
            {
                
                currentWayPointId = lastWayPointId;
                lastWayPointId = currentWayPointId + moveDirection;
                moveDirection = -1;
            }
            moveSpeed = WalkSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && enabledMove)
        {
            if (currentWayPointId < lastWayPointId)
            {
                
                currentWayPointId = lastWayPointId;
                lastWayPointId = currentWayPointId + moveDirection;
                moveDirection = 1;
            }
            moveSpeed = WalkSpeed;
        }
        else
        {
            moveSpeed = 0;
        }
    }

    public void EnableMovement(bool state)
    {
        if (state)
        {
            enabledMove = true;

        }
        else
        {
            enabledMove = false;
        }
    }
}
