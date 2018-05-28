using UnityEngine;

public class MenuIndicator : MonoBehaviour {

    Menu menu;
    Animator anim;

    Vector3 positionLeftIndicator;
    Vector3 positionRightIndicator;

    void Start () {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

	void Update () {
        //anim.Play("IdleMenuIndicator");

        if (gameObject.name == "IndicatorLeft")
        {
            positionLeftIndicator = transform.position;
            positionLeftIndicator = menu.OptionPositionLeft;
            //positionLeftIndicator = transform.position;
            transform.position = positionLeftIndicator;
        }
        if (gameObject.name == "IndicatorRight")
        {
            positionRightIndicator = transform.position;
            positionRightIndicator = menu.OptionPositionRight;
            transform.position = positionRightIndicator;
        }
    }
}
