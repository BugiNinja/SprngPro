using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private bool isHit;
    public bool isDead;

    public int healthMax;
    public int healthCurrent;

	void Start () {
        isHit = false;
        isDead = false;

        healthMax = 3;
        healthCurrent = healthMax;
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
            healthCurrent--;
            isHit = false;
        }
    }

    public void CheckIfDead()
    {
        if(healthCurrent <= 0)
        {
            healthCurrent = 0;
            isDead = true;
            Debug.Log("You died!");
        }
    }
}
