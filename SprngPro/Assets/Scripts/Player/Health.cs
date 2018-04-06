using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private PlayerStats stats; 
    Animator anim;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("healthStage", stats.HealthCurrent);
    }
}
