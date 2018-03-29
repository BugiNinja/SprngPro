using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathMove : MonoBehaviour {

    string pathName = "PlayerPath";
    EditorPath PathToFollow;

    public int SpawnNodeId = 0;
    int currentWayPointId = 0;
    int lastWayPointId = 0;

    int moveDirection = 1; //1 = forward, -1 = backward 

    public float WalkSpeed = 20;
    float moveSpeed = 0;

    private float reachDistance = 0.6f;

    

    void Start()
    {
        PathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        currentWayPointId = SpawnNodeId;
        lastWayPointId = SpawnNodeId - 1;
        transform.position = PathToFollow.nodes[currentWayPointId].position;
    }

    void Update()
    {
        CheckMovement();
        float distance = Vector3.Distance(PathToFollow.nodes[currentWayPointId].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.nodes[currentWayPointId].position, Time.deltaTime * moveSpeed);

        if (distance <= reachDistance)
        {
            
            lastWayPointId = currentWayPointId;
            currentWayPointId += moveDirection;

        }

    }
    void CheckMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(currentWayPointId > lastWayPointId)
            {
                
                currentWayPointId = lastWayPointId;
                lastWayPointId = currentWayPointId + moveDirection;
                moveDirection = -1;
            }
            moveSpeed = WalkSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
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
}
