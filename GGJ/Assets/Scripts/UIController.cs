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
        coinPJ2.text = gManager.PJ2.money + "";

        CountDown.text = "00:" + (int)gManager.TimeCountDown;

    }

    
    public void RepairBuilding(int i)
    {
        gManager.edificios[i].life = 1f;
    }

    public void nextRound()
    {
        for(int i = 0; i < gManager.edificios.Count; i++){

            PlayerPrefs.SetFloat(i + "", gManager.edificios[i].life);

        }


        Application.LoadLevel(2);
    }
    public Text winText;
    public void win()
    {
        if (gManager.PJ1.money < gManager.PJ2.money)
        {
            winText.text = "PLAYER 2 WINS";
        }
        else
        {
            winText.text = "PLAYER 1 WINS";
        }
    }

    public void finishMatch()
    {
        Application.LoadLevel(0);
    }

    public void activePJ1Shop()
    {
        PJ1Shop.SetActive(true);
    }

    public void finishBuyPJ1()
    {
        PJ1Shop.SetActive(false);
        PJ2Shop.SetActive(true);
    }

}
