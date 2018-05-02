using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathMove : MonoBehaviour {

    private FileManager fileManager;
    public Animator anim;

    public int SpawnNodeId = 0;
    public float WalkSpeed = 2;

    private string pathName = "PlayerPath";
    private EditorPath pathToFollow;

    private bool enabledMove = true;

    private int currentWayPointId = 0;
    public int LastWayPointId; //Tallennukseen

    private int moveDirection = 1; //1 = forward, -1 = backward 
    private float moveSpeed = 0;
    private float reachDistance = 1f;

    private bool walking;
    public bool TakeAStep;

    private void Start()
    {
        fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
        if (!fileManager)
        {
            Debug.Log("FileManager doesn't exist!");
        }
        pathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        currentWayPointId = SpawnNodeId;
        LastWayPointId = SpawnNodeId - 1;
        transform.position = pathToFollow.Nodes[currentWayPointId].position;
        walking = false;
    }

    private void Update()
    {
        CheckMovement();
        float distance = Vector3.Distance(pathToFollow.Nodes[currentWayPointId].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.Nodes[currentWayPointId].position, Time.deltaTime * moveSpeed);

        if (distance <= reachDistance)
        {
            
            LastWayPointId = currentWayPointId;
            currentWayPointId += moveDirection;

        }
        fileManager.WayPoint = LastWayPointId;
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
                Flip();
            }
            enabledMove = true;
            anim.SetBool("Walking", true);
            walking = true;
            moveSpeed = WalkSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && enabledMove)
        {
            if (currentWayPointId < LastWayPointId)
            {
                currentWayPointId = LastWayPointId;
                LastWayPointId = currentWayPointId + moveDirection;
                moveDirection = 1;
                Flip();
            }
            enabledMove = true;
            anim.SetBool("Walking", true);
            walking = true;
            moveSpeed = WalkSpeed;
        }
        else
        {
            moveSpeed = 0;
            anim.SetBool("Walking", false);
            walking = false;
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

    void Flip()
    {
        if (!walking)
        {
            transform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("Walking", false);
            walking = false;
            transform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
            enabledMove = false;
        }
    }
}
