using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathMove : MonoBehaviour {

    public Animator anim;

    public int SpawnNodeId = 0;
    public float WalkSpeed = 10;

    private string pathName = "PlayerPath";
    private EditorPath pathToFollow;

    private bool enabledMove = true;

    private int currentWayPointId = 0;
    public int LastWayPointId;// = FileManager.Instance.WayPoint; //Tallennukseen

    private int moveDirection = 1; //1 = forward, -1 = backward 
    private float moveSpeed = 0;
    public float WalkAnim = 1;
    private float reachDistance = 1f;

    private void Start()
    {
        pathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        currentWayPointId = SpawnNodeId;
        LastWayPointId = SpawnNodeId - 1;
        transform.position = pathToFollow.Nodes[currentWayPointId].position;
    }

    private void Update()
    {
        CheckMovement();
        if (moveSpeed > 0)
        {
            float distance = Vector3.Distance(pathToFollow.Nodes[currentWayPointId].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pathToFollow.Nodes[currentWayPointId].position, Time.deltaTime * moveSpeed * WalkAnim);


            if (distance <= reachDistance)
            {

                LastWayPointId = currentWayPointId;
                currentWayPointId += moveDirection;

            }
        }

        //FileManager.Instance.WayPoint = LastWayPointId;
    }

    public void ChangeSpawnPoint(bool right)
    {
        if (right)
        {
            SpawnNodeId = 0;
        }
        else
        {
            SpawnNodeId = pathToFollow.Nodes.Count;
        }
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.A) && enabledMove)
        {
            if (currentWayPointId > LastWayPointId)
            {                
                currentWayPointId = LastWayPointId;
                LastWayPointId = currentWayPointId + moveDirection;
                moveDirection = -1;
            }
            if(currentWayPointId < 0 || currentWayPointId >= pathToFollow.Nodes.Count)
            {
                currentWayPointId = LastWayPointId;
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = WalkSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.D) && enabledMove)
        {
            if (currentWayPointId < LastWayPointId)
            {
                
                currentWayPointId = LastWayPointId;
                LastWayPointId = currentWayPointId + moveDirection;
                moveDirection = 1;
            }
            if (currentWayPointId < 0 || currentWayPointId >= pathToFollow.Nodes.Count)
            {
                currentWayPointId = LastWayPointId;
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = WalkSpeed;
            }
            moveSpeed = WalkSpeed;
        }
        /*else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Walking", false);
            moveSpeed = 0;
        }*/
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
