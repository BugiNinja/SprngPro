using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathMove : MonoBehaviour {

    private FileManager fileManager;
    public Animator anim;

    public int SpawnNodeId = 0;

    public float WalkSpeed = 2;

    private string pathName = "PlayerPath";
    private NodePath pathToFollow;

    public bool enabledMove = true;

    private int CurrentWayPointId = 0;
    public int LastWayPointId; //Tallennukseen

    private int moveDirection = 1; //1 = forward, -1 = backward 
    private float moveSpeed = 0;
    public float WalkAnim = 1;
    private float reachDistance = 1f;
    private bool forceMovement;

    public bool TakeAStep;
    private bool flipped;

    private void Start()
    {
        flipped = false;

        fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
        if (!fileManager)
        {
            Debug.Log("FileManager doesn't exist!");
        }
        GetPathToFollow();
        
        CurrentWayPointId = SpawnNodeId;
        LastWayPointId = SpawnNodeId - 1;
        transform.position = pathToFollow.Nodes[CurrentWayPointId].position;
    }

    private void GetPathToFollow()
    {
        pathToFollow = GameObject.Find(pathName).GetComponent<NodePath>();
        if (pathToFollow == null)
        {
            Debug.Log("PlayerPath doesn't exist or is named wrong!");
        }
    }

    private void Update()
    {
        CheckInput();
        if (moveSpeed > 0)
        {
            float distance = Vector3.Distance(pathToFollow.Nodes[CurrentWayPointId].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pathToFollow.Nodes[CurrentWayPointId].position, Time.deltaTime * moveSpeed * WalkAnim);


            if (distance <= reachDistance)
            {

                LastWayPointId = CurrentWayPointId;
                CurrentWayPointId += moveDirection;

            }
        }

        if (flipped)
        {
            AnimatorStateInfo ai = anim.GetCurrentAnimatorStateInfo(0);
            if (ai.IsName("Idle"))
            {
                Flip();
                flipped = false;
            }           
        }

        fileManager.WayPoint = LastWayPointId;
    }

    public void ChangeSpawnPoint(bool right)
    {
        if (right)
        {
            SpawnNodeId = 1;
        }
        else
        {
            GetPathToFollow();
            SpawnNodeId = pathToFollow.Nodes.Count - 2;
            ChangeDirection(-1);
            Flip();
        }
    }

    private void CheckInput()
    {
        if (forceMovement)
        {
            ForceMovement();
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || flipped)
        {
            anim.SetBool("Walking", false);
            moveSpeed = 0;
        }
        else if (Input.GetKey(KeyCode.A) && enabledMove)
        {
            if (CurrentWayPointId > LastWayPointId)
            {
                ChangeDirection(-1);
            }
            CheckMovement();
        }

        else if (Input.GetKey(KeyCode.D) && enabledMove)
        {
            if (CurrentWayPointId < LastWayPointId)
            {
                ChangeDirection(1);
            }
            CheckMovement();
        }

        else
        {
            moveSpeed = 0;
            anim.SetBool("Walking", false);
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

    void Walk()
    {
        anim.SetBool("Walking", true);
        enabledMove = true;
        moveSpeed = WalkSpeed;
    }
    void ForceMovement()
    {
        anim.SetBool("Walking", true);
        enabledMove = true;
        moveSpeed = WalkSpeed;
    }
    public void StartForceMovement()
    {
        forceMovement = true;
    }
    public void StopForceMovement()
    {
        forceMovement = false;
    }
    void Flip()
    {
        transform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
    }

    void ChangeDirection(int direction)
    {
        CurrentWayPointId = LastWayPointId;
        LastWayPointId = CurrentWayPointId + moveDirection;
        moveDirection = direction;
        anim.SetBool("Walking", false);
        flipped = true;
    }

    void CheckMovement()
    {
        if (CurrentWayPointId < 0 || CurrentWayPointId >= pathToFollow.Nodes.Count)
        {
            CurrentWayPointId = LastWayPointId;
            moveSpeed = 0;
        }
        else
        {
            Walk();
        }
    }
    public int GetCurrentWayPoint()
    {
        return CurrentWayPointId;
    }
    public int GetNodeLength()
    {
        return pathToFollow.Nodes.Count;
    }
    public Transform GetNode(int index)
    {
        return pathToFollow.Nodes[index];
    }
}
