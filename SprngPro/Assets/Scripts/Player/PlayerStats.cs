using UnityEngine;
using UnityEngine.Audio;

public class PlayerStats : MonoBehaviour {

    //private FileManager fileManager;
    public Animator anim;
    //private GameObject deathScreen;
    private PlayerPathMove ppm;
    private bool isHit;
    private bool isDead;

    public int HealthMax;
    public int HealthCurrent; //Tallennukseen

	void Start () {
        //fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
        /*if (!fileManager)
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
        ppm = gameObject.GetComponent<PlayerPathMove>();
        if(ppm == null)
        {
            Debug.Log("mo");
        }
        isHit = false;
        isDead = false;

        //HealthMax = 3;
        //HealthCurrent = fileManager.Health;
	}
	
	void Update () {
        CheckIfDead();
        //Die();
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
        if(gameObject != null)
        {
            if (ppm == null)
            {
                ppm = gameObject.GetComponent<PlayerPathMove>();
            }
            if (ppm != null)
            {
                ppm.EnableMovement(false);
                Anima2D.SpriteMeshInstance[] smi = GetComponentsInChildren<Anima2D.SpriteMeshInstance>();
                for (int i = 0; i < smi.Length; i++)
                {
                    smi[i].sortingLayerID = SortingLayer.NameToID("UI");
                }
                //deathScreen.gameObject.SetActive(true);
                anim.SetBool("Dead", true);
                Time.timeScale = 0;
            }
        }
        



    }
}
