using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    private ProgressManager pm;
    private DialogueManager dm;
    private Dynamicamera dc;
    int startSpot = 6;
    int direction = 0;
    private void Start()
    {
        pm = FindObjectOfType<ProgressManager>();
        dm = FindObjectOfType<DialogueManager>();
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(sceneIndex);

    }
    public void ChangeScene(int sceneIndex, int direction) //direction: 1=right -1=left
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(sceneIndex);
        this.direction = direction;

    }
    public void ChangeSceneWithFade(int sceneIndex)
    {
        dc.Fade(sceneIndex);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        dc = FindObjectOfType<Dynamicamera>();
        PlayerPathMove ppm = FindObjectOfType<PlayerPathMove>();
        if (ppm != null)
        {
            if (direction == 1)
            {
                ppm.ChangeSpawnPoint(true);
            }
            else if (direction == -1)
            {
                ppm.ChangeSpawnPoint(false);
            }
        }
        if (pm != null)
        {
            pm.UpdateCharacters();
            pm.UpdateInteractable();
            dm.UpdatePlayer();
        }

    }
}
