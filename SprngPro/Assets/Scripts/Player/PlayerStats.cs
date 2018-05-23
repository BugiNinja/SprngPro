using UnityEngine;
using UnityEngine.Audio;

public class PlayerStats : MonoBehaviour {

    //private FileManager fileManager;
    //public Animator anim;
    //private GameObject deathScreen;

    private bool isHit;

    public int HealthMax;
    public int HealthCurrent; //Tallennukseen

	void Start () {
        //fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
        /* if (!fileManager)
        {
            Debug.Log("FileManager doesn't exist!");
        }

        deathScreen = GameObject.Find("DeathScreen");
        if (!deathScreen)
        {
            Debug.Log("No DeathScreen in hierarchy!");
        }
        else
        {
            deathScreen.gameObject.SetActive(false);
        }

        if (!anim)
        {
            Debug.Log("Animator missing!!");
        }*/

        isHit = false;

        //HealthMax = 3;
        //HealthCurrent = fileManager.Health;
	}
	
	void Update () {
        TakeDamage();
        //CheckIfDead();
    }

    public void TakeDamage()
    {
        
        HealthCurrent--;
        isHit = false;
        
    }

    public int GetHealth()
    {
        return HealthCurrent;
    }

    public void CheckIfDead()
    {
        if(HealthCurrent <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //deathScreen.gameObject.SetActive(true);
        //anim.Play("AppearDeathScreen");
        Debug.Log("juu died");
        Time.timeScale = 0;
    }
}
