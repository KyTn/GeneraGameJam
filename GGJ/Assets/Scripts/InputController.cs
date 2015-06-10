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
    public float LButton;

    public float RLTrigger;

    public float mouseXPos;
    public float mouseXNeg;
    public float mouseYPos;
    public float mouseYNeg;

    public float startButton;
    public float backButton;

    public float upArrowButton;
    public float downArrowButton;
    public float leftArrowButton;
    public float rightArrowButton;


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
        LButton = Input.GetButton("J1LButton") ? 1 : 0;

        RLTrigger = Input.GetAxis("J1RLTrigger");

        mouseXPos = Input.GetAxis("J1VerticalRight") > 0 ? Input.GetAxis("J1VerticalRight") : 0;
        mouseXNeg = -Input.GetAxis("J1VerticalRight") > 0 ? -Input.GetAxis("J1VerticalRight") : 0;
        mouseYPos = Input.GetAxis("J1HorizontalRight") > 0 ? Input.GetAxis("J1HorizontalRight") : 0;
        mouseYNeg = -Input.GetAxis("J1HorizontalRight") > 0 ? -Input.GetAxis("J1HorizontalRight") : 0;

        startButton = Input.GetButton("J1StartButton") ? 1 : 0;
        backButton = Input.GetButton("J1BackButton") ? 1 : 0;

        upArrowButton = Input.GetAxis("J1VerticalCenter") > 0 ? Input.GetAxis("J1VerticalCenter") : 0;
        downArrowButton = -Input.GetAxis("J1VerticalCenter") > 0 ? -Input.GetAxis("J1VerticalCenter") : 0;
        leftArrowButton = Input.GetAxis("J1HorizontalCenter") > 0 ? Input.GetAxis("J1HorizontalCenter") : 0;
        rightArrowButton = -Input.GetAxis("J1HorizontalCenter") > 0 ? -Input.GetAxis("J1HorizontalCenter") : 0;


    }
}