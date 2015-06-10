using UnityEngine;
using System.Collections;

public class PlayerInfoGame : MonoBehaviour {

    public GameManager gManager;

    #region Player Vars

    public int IDJugador = 0; // 1 para J1, 2 para J2

    private float _health = 1f;
    public float health
    {
        get
        {
            return _health;
        }

        set
        {
            
            _health = value;
            _health = Mathf.Clamp(_health, 0,1);
            if (_health < 0)
            {
                Death();
            }
        }
    }

    private int _money = 0;

    public int money
    {
        get
        {
            return _money;
        }

        set
        {
            _money = value;
        }
    }

    #endregion



    public void Death()
    {
        gManager.PlayerDeath(IDJugador);

    }
}
