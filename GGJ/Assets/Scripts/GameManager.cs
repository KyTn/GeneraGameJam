using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    public InputController icontroller;

    public int premioMuerte = 2000;
    public int premioGolpe = 100;

    public List<Buildings> edificios;

    public UIController uiController;

    public bool MultiPlayerActive = false;

    public float TimeCountDown = 60f;

    public delegate void finishGameDelegate();
    public event finishGameDelegate finishGameEvent;

    public bool cargaPrefs = false;

    public PlayerInfoGame PJ1;
    public PlayerInfoGame PJ2;

    public List<GameObject> ThrowablesMocoSoftPresente;
    public List<GameObject> ThrowablesPooglePresente;
    public List<GameObject> ThrowablesMocoSoftFuturo;
    public List<GameObject> ThrowablesPoogleFuturo;

    public void Awake()
    {

    }

	// Use this for initialization
	void Start () {
        if (cargaPrefs)
        {
            loadPlayerPref();
        }
        //StartCoroutine(CountDownStart());

	}
	
	// Update is called once per frame
    void Update()
    {

        if (!PJ1.preparingToAttack)
        {
            PJ1.rigidbody2D.velocity = new Vector2((-icontroller.J1left + icontroller.J1right) * PJ1.speed * (PJ1.isJumping || PJ1.jumpsCount != 0 ? 0.4f : 1), PJ1.rigidbody2D.velocity.y);

            if (!PJ1.isJumping && icontroller.J1AButton > 0)
            {
                //Debug.Log("JUMP");
                PJ1.Jump(new Vector2(0, icontroller.J1AButton));

            }
        }
        // Si he pulsado B, me preparo para atacar
        if (icontroller.J1XButton > 0)
        {
            //Debug.Log("X");
            if (PJ1.carringObject)
            {
                PJ1.preparingToAttack = true;
            }
        }
        // si he dejado de pulsar pero estaba preparado para atacar, ataco
        else if (PJ1.preparingToAttack)
        {
            //Vector3 aux = new Vector3(-icontroller.J1left + icontroller.J1right, icontroller.J1forward - icontroller.J1backward, 0);
            PJ1.ThrowObject(PJ1.throwDirection);
        }

        if (MultiPlayerActive)
        {

            if (!PJ2.preparingToAttack)
            {
                PJ2.rigidbody2D.velocity = new Vector2((-icontroller.J2left + icontroller.J2right) * PJ2.speed * (PJ2.isJumping || PJ2.jumpsCount != 0 ? 0.4f : 1), PJ2.rigidbody2D.velocity.y);

                if (!PJ2.isJumping && icontroller.J2AButton > 0)
                {
                    //Debug.Log("JUMP");
                    PJ2.Jump(new Vector2(0, icontroller.J2AButton));

                }
            }
            // Si he pulsado B, me preparo para atacar
            if (icontroller.J2XButton > 0)
            {
                Debug.Log("X");
                if (PJ2.carringObject)
                {
                    PJ2.preparingToAttack = true;
                }
            }
            // si he dejado de pulsar pero estaba preparado para atacar, ataco
            else if (PJ2.preparingToAttack)
            {
                //Vector3 aux = new Vector3(-icontroller.J1left + icontroller.J1right, icontroller.J1forward - icontroller.J1backward, 0);
                PJ2.ThrowObject(PJ2.throwDirection);
            }

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
                //PlayerDeath(PJ1.money < PJ2.money? 2 : 1);
                finishGameEvent();
            }

        }

    }
    public AudioClip clipmuerte;
    public AudioSource asource;

    public void PlayerDeath(int IDJugador)
    {
        asource.clip = clipmuerte;
        asource.Play();
        
        if (IDJugador == 1)
        {
            PJ2.money = premioMuerte;
        }
        else
        {
            PJ1.money = premioMuerte;
        }
        StartCoroutine(lanzaMenu());

        //int aux = 0;
        //foreach(Buildings i in edificios)

    }



    IEnumerator lanzaMenu()
    {

        Time.timeScale = 0.3f;

        yield return new WaitForSeconds(0.3f);

        Time.timeScale = 1f;
        if (!cargaPrefs) uiController.activePJ1Shop();
        else uiController.win();
    }

    public void loadPlayerPref()
    {
        if (PlayerPrefs.HasKey("0"))
        {
            edificios[0].life = PlayerPrefs.GetInt("0");
        }
        if (PlayerPrefs.HasKey("1"))
        {
            edificios[0].life = PlayerPrefs.GetInt("1");
        }
        if (PlayerPrefs.HasKey("2"))
        {
            edificios[0].life = PlayerPrefs.GetInt("2");
        }
        if (PlayerPrefs.HasKey("3"))
        {
            edificios[0].life = PlayerPrefs.GetInt("3");
        }
        if (PlayerPrefs.HasKey("4"))
        {
            edificios[0].life = PlayerPrefs.GetInt("4");
        }
        if (PlayerPrefs.HasKey("5"))
        {
            edificios[0].life = PlayerPrefs.GetInt("5");
        }
        if (PlayerPrefs.HasKey("6"))
        {
            edificios[0].life = PlayerPrefs.GetInt("6");
        }
        if (PlayerPrefs.HasKey("7"))
        {
            edificios[0].life = PlayerPrefs.GetInt("7");
        }

        PJ1.money = PlayerPrefs.GetInt("coinPJ1");
        PJ2.money = PlayerPrefs.GetInt("coinPJ2");



    }

}
