using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private bool isHit;
    //private bool isDead;

    private int healthMax;
    public int HealthCurrent;

	void Start () {
        isHit = false;
        //isDead = false;

        healthMax = 3;
        HealthCurrent = healthMax;
	}
	
	void Update () {
        TakeDamage();
        CheckIfDead();
	}

    public void TakeDamage()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isHit = true;
        }

        if (isHit)
        {
            HealthCurrent--;
            isHit = false;
        }
    }

    public void CheckIfDead()
    {
        if(HealthCurrent <= 0)
        {
            HealthCurrent = 0;
            //isDead = true;
            Debug.Log("You died!");
        }
    }
}
