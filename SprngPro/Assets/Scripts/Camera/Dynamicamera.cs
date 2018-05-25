using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamicamera : MonoBehaviour {

    private GameObject player;
    private Camera c;
    private GameObject background;
    public Vector3 offset;
    private float backgroundmin;
    private float backgroundmax;
    private float newPositionX;
    public Vector3 stopPosition;
    private SceneChange sm;
    public int NextSceneNumber;
    public int PrevSceneNumber;
    private PlayerPathMove ppm;
    private int scene;
    private bool startFade;
    private float fadeValue;
    private float fadeSpeed = 10;

    public float cameraDistance;
    private float MaxSize = 9;
    private float MinSize = 7;
    public float ScaleSpeed = 0.05f;

    Color fade;
    SpriteRenderer fadeSR;

    void Start()
    {
        sm = GameObject.Find("SceneManager").GetComponent<SceneChange>();
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.FindGameObjectWithTag("Background");
        if(background == null)
        {
            Debug.LogWarning("missing background bound!");
        }
        if(player == null)
        {
            Debug.LogWarning("player is missing or don't have player tag!");
        }
        else
        {
            ppm = player.GetComponent<PlayerPathMove>();
        }
        c = gameObject.GetComponent<Camera>();
        c.orthographicSize = MinSize;
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, 2, -10);
        backgroundmin = background.GetComponent<Renderer>().bounds.min.x;
        backgroundmax = background.GetComponent<Renderer>().bounds.max.x;
        fadeSR = gameObject.GetComponentInChildren<SpriteRenderer>();
        fade = new Color(0, 0, 0, 255);
        fadeSR.color = fade;
        stopPosition = Vector3.zero;
        
    }


    void Update()
    {
        if (!startFade)
        {
            newPositionX = player.transform.position.x + offset.x;

            if (InBounds())
            {
                //ScaleSize();
                transform.position = player.transform.position + offset;
            }
            else
            {
                if ((transform.position.x - (c.orthographicSize * 2 * c.aspect / 2) - (transform.position.x - newPositionX) <= backgroundmin))
                {
                    ScreenTransition(1);
                }
                else if (transform.position.x + (c.orthographicSize * 2 * c.aspect / 2) + (newPositionX - transform.position.x) >= backgroundmax)
                {
                    ScreenTransition(-1);
                }
            }

        }
        else
        {
            fadeValue = fadeValue + 0.1f * fadeSpeed * Time.deltaTime;
            fade = new Color(0, 0, 0, fadeValue);
            fadeSR.color = fade;
            if(fadeValue >= 1)
            {
                sm.ChangeScene(scene);
            }
        }
    }
    bool InBounds()
    {
        if (transform.position.x - (c.orthographicSize * 2 * c.aspect / 2) - (transform.position.x - newPositionX) <= backgroundmin || transform.position.x + (c.orthographicSize * 2 * c.aspect / 2) + (newPositionX - transform.position.x) >= backgroundmax)
        {
            return false;
        }
        else
        {
            stopPosition = Vector3.zero;
            fadeSR.color = new Color(0, 0, 0, 0);
            return true;
        }
    }
    void ScreenTransition(int direction) //right = -1 left = 1
    {
        
        if (stopPosition == Vector3.zero)
        {
            stopPosition = player.transform.position;
            if(direction == 1)
            {
                stopPosition.x = backgroundmin + MinSize * c.aspect;
            }
            else if(direction == -1)
            {
                stopPosition.x = backgroundmax - MinSize * c.aspect;
            }
        }
        stopPosition.y = player.transform.position.y;
        cameraDistance = Vector3.Distance(player.transform.position, stopPosition);
        cameraDistance = cameraDistance / (MinSize * c.aspect);
        float fadeDistance = 0;
        if(cameraDistance >= 0.7)
        {
            fadeDistance = cameraDistance * 10 - 7;
            ppm.StartForceMovement();
        }
        else
        {
            ppm.StopForceMovement();
        }
        if(cameraDistance >= 0.9)
        {
            if (direction == 1)
            {
                sm.ChangeScene(PrevSceneNumber, -1);
            }
            else if (direction == -1)
            {
                sm.ChangeScene(NextSceneNumber, 1);
            }
        }
        if (c.orthographicSize >= MaxSize)
        {
            c.orthographicSize = MaxSize;
            cameraDistance = 1;
            
        }
        c.orthographicSize = MinSize + ((MaxSize - MinSize) * cameraDistance);
        fade = new Color(0, 0, 0, fadeDistance);
        fadeSR.color = fade;
        c.transform.position = stopPosition + (new Vector3(((MaxSize - MinSize) * c.aspect * cameraDistance * direction), ((MaxSize - MinSize) + 2 * cameraDistance), -10));
    }
    void ScaleSize()
    {
        if (newPositionX != transform.position.x)
        {
            if (c.orthographicSize < MaxSize)
            {
                c.orthographicSize += ScaleSpeed;
            }
        }
        else
        {
            if (c.orthographicSize > MinSize)
            {
                c.orthographicSize -= ScaleSpeed;
            }
        }
    }
    public void Fade(int scene)
    {
        this.scene = scene;
        startFade = true;
    }
}
