using UnityEngine;
using UnityEngine.Audio;

public class PlayerStats : MonoBehaviour {

    public Animator anim;
    private GameObject deathScreen;

    private bool isHit;
    private bool isDead;

    public int HealthMax;
    public int HealthCurrent; //Tallennukseen

	void Start () {
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.gameObject.SetActive(false);

        isHit = false;
        isDead = false;

        //HealthMax = 3;
        HealthCurrent = FileManager.Instance.Health;
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
            FileManager.Instance.Health--;
            isHit = false;
        }
    }

    public int GetHealth()
    {
        return HealthCurrent;
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
