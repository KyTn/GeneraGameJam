﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerInfoGame : MonoBehaviour {

    public GameManager gManager;

    #region Player Vars

    public int IDPlayer = 0; // 1 para J1, 2 para J2

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

    public Throwable objectCarried = null;

    public bool carringObject
    {
        get
        {
            return objectCarried != null;
        }
    }

    public bool Moving = false;


    #endregion


    public void MoveTo(Vector3 position)
    {
        if (!Moving)
        {
            Vector3[] path = new Vector3[2];
            path[1] = position;
            path[0] = new Vector3((position.x + transform.position.x) / 2, (position.y + transform.position.y) / 2 + 2, (position.y + transform.position.y) / 2);
            transform.DOPath(path, 0.8f, PathType.CatmullRom, PathMode.Full3D, 5);
        }
    }


    public void PickUpObject(Throwable obj)
    {
        objectCarried = obj;
        objectCarried.carriedBy = IDPlayer;

    }

    public void ThrowObject(Vector2 v)
    {
        if (carringObject)
        {
            objectCarried.ThrowObject(v);
        }
    }

    public void Death()
    {
        gManager.PlayerDeath(IDPlayer);

    }
}
