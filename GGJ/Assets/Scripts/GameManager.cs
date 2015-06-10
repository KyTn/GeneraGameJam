using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

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
