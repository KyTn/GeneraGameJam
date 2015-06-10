﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    public InputController icontroller;


    public bool MultiPlayerActive = false;

    public float TimeCountDown = 60f;

    public delegate void finishGameDelegate();
    public event finishGameDelegate finishGameEvent;


    public PlayerInfoGame PJ1;
    public PlayerInfoGame PJ2;

    public void Awake()
    {

    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {


        PJ1.rigidbody2D.velocity = new Vector2((-icontroller.J1left + icontroller.J1right) * PJ1.speed * (PJ1.isJumping || PJ1.jumpsCount!=0 ? 0.4f : 1), PJ1.rigidbody2D.velocity.y);

        if (!PJ1.isJumping && icontroller.J1AButton > 0)
        {
            Debug.Log("JUMP");
            PJ1.Jump(new Vector2(0, icontroller.J1AButton));
            
        }

        // Si he pulsado B, me preparo para atacar
        if (icontroller.J1BButton > 0)
        {
            if (PJ1.carringObject)
            {
                PJ1.preparingToAttack = true;
            }
        }
            // si he dejado de pulsar pero estaba preparado para atacar, ataco
        else if (PJ1.preparingToAttack)
        {
            Vector3 aux = new Vector3(-icontroller.J1left + icontroller.J1right, icontroller.J1forward - icontroller.J1backward, 0);
            PJ1.ThrowObject(aux);
        }

        if (MultiPlayerActive)
        {
            
        }

	}


    IEnumerator CountDownStart()
    {
        float now = Time.time;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            TimeCountDown-= Time.time - now;
            now = Time.time;

            if (TimeCountDown < 0)
            {
                finishGameEvent();
            }

        }

    }

    public void PlayerDeath(int IDJugador)
    {

    }


}
