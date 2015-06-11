using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameManager gManager;

    public Text coinPJ1;
    public Text coinPJ2;

    public Text CountDown;


    public GameObject PJ1Shop;
    public Text PJ1button1;
    public Text PJ1button2;
    public Text PJ1button3;
    public Text PJ1button4;

    public GameObject PJ2Shop;
    public Text PJ2button1;
    public Text PJ2button2;
    public Text PJ2button3;
    public Text PJ2button4;

    public void Update()
    {
        coinPJ1.text = gManager.PJ1.money + "";
        coinPJ1.text = gManager.PJ2.money + "";

        CountDown.text = "00:" + (int)gManager.TimeCountDown;

    }


    public void nextRound()
    {
        Application.LoadLevel(-1);
    }

    public void finishMatch()
    {
        Application.LoadLevel(0);
    }
	
}
