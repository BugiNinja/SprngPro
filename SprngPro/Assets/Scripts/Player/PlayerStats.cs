using UnityEngine;
using UnityEngine.Audio;

public class PlayerStats : MonoBehaviour {

    public Animator anim;
    private GameObject deathScreen;

    private bool isHit;
    private bool isDead;

    private int healthMax;
    public int HealthCurrent;

	void Start () {
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.gameObject.SetActive(false);

        isHit = false;
        isDead = false;

        healthMax = 3;
        HealthCurrent = healthMax;
	}
	
	void Update () {
        TakeDamage();
        CheckIfDead();
        Die();
	}

    public void TakeDamage()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isHit = true;
            FindObjectOfType<AudioManager>().PlaySound("TakeDamage");
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
            isDead = true;
        }
    }

    public void Die()
    {
        if(isDead)
        {
            deathScreen.gameObject.SetActive(true);
            anim.Play("AppearDeathScreen");
            Time.timeScale = 0;
        }
    }
}
