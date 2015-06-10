using UnityEngine;

using System.Collections;

public class InputController : MonoBehaviour
{

    GameManager gManager;
    public float J1forward;
    public float J1backward;
    public float J1left;
    public float J1right;

    public float J1AButton;
    public float J1BButton;
    public float J1XButton;
    public float J1YButton;

    public float J1RButton;
    public float J1LButton;
                 
    public float J1RLTrigger;
                 
    public float J1mouseXPos;
    public float J1mouseXNeg;
    public float J1mouseYPos;
    public float J1mouseYNeg;
                 
    public float J1startButton;
    public float J1backButton;
                 
    public float J1upArrowButton;
    public float J1downArrowButton;
    public float J1leftArrowButton;
    public float J1rightArrowButton;


    void Awake()
    {
        gManager = GetComponent<GameManager>();
    }


    void Update()
    {


        J1forward = Input.GetAxis("J1VerticalLeft") > 0 ? Input.GetAxis("J1VerticalLeft") : 0;
        J1backward = -Input.GetAxis("J1VerticalLeft") > 0 ? -Input.GetAxis("J1VerticalLeft") : 0;
        J1right = Input.GetAxis("J1HorizontalLeft") > 0 ? Input.GetAxis("J1HorizontalLeft") : 0;
        J1left = -Input.GetAxis("J1HorizontalLeft") > 0 ? -Input.GetAxis("J1HorizontalLeft") : 0;

        J1AButton = Input.GetButton("J1AButton") ? 1 : 0;
        J1BButton = Input.GetButton("J1BButton") ? 1 : 0;
        J1XButton = Input.GetButton("J1XButton") ? 1 : 0;
        J1YButton = Input.GetButton("J1YButton") ? 1 : 0;

        J1RButton = Input.GetButton("J1RButton") ? 1 : 0;
        J1LButton = Input.GetButton("J1LButton") ? 1 : 0;
        
        J1RLTrigger = Input.GetAxis("J1RLTrigger");
        
        J1mouseXPos = Input.GetAxis("J1VerticalRight") > 0 ? Input.GetAxis("J1VerticalRight") : 0;
        J1mouseXNeg = -Input.GetAxis("J1VerticalRight") > 0 ? -Input.GetAxis("J1VerticalRight") : 0;
        J1mouseYPos = Input.GetAxis("J1HorizontalRight") > 0 ? Input.GetAxis("J1HorizontalRight") : 0;
        J1mouseYNeg = -Input.GetAxis("J1HorizontalRight") > 0 ? -Input.GetAxis("J1HorizontalRight") : 0;
        
        J1startButton = Input.GetButton("J1StartButton") ? 1 : 0;
        J1backButton = Input.GetButton("J1BackButton") ? 1 : 0;
        
        J1upArrowButton = Input.GetAxis("J1VerticalCenter") > 0 ? Input.GetAxis("J1VerticalCenter") : 0;
        J1downArrowButton = -Input.GetAxis("J1VerticalCenter") > 0 ? -Input.GetAxis("J1VerticalCenter") : 0;
        J1leftArrowButton = Input.GetAxis("J1HorizontalCenter") > 0 ? Input.GetAxis("J1HorizontalCenter") : 0;
        J1rightArrowButton = -Input.GetAxis("J1HorizontalCenter") > 0 ? -Input.GetAxis("J1HorizontalCenter") : 0;


    }
}