using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerInfoGame : MonoBehaviour {

    public GameManager gManager;

    public Transform hand;


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
        //if (!Moving)
        //{
        //    Vector3[] path = new Vector3[2];
        //    path[1] = position;
        //    path[0] = new Vector3((position.x + transform.position.x) / 2, (position.y + transform.position.y) / 2 + 2, (position.y + transform.position.y) / 2);
        //    transform.DOPath(path, 0.8f, PathType.CatmullRom, PathMode.Full3D, 5).OnComplete(MoveToCallback);
        //}
    }
    public void MoveToCallback()
    {
        Moving = false;
    }

    public void PickUpObject(Throwable obj)
    {
        if (carringObject) return;

        objectCarried = obj;
        objectCarried.carriedBy = IDPlayer;
        objectCarried.transform.parent = hand;
        objectCarried.transform.localPosition = Vector3.zero;

        // activar animacion portador de objetos


    }
    public GameObject arrow;
    public Vector3 throwDirection;
    public void DrawArrow()
    {
        Vector3 ammount;
        if (IDPlayer == 1)
        {
            ammount = new Vector3(-gManager.icontroller.J1left + gManager.icontroller.J1right, gManager.icontroller.J1forward - gManager.icontroller.J1backward, 0);

        }
        else
        {
            ammount = new Vector3(-gManager.icontroller.J2left + gManager.icontroller.J2right, gManager.icontroller.J2forward - gManager.icontroller.J2backward, 0);

        }
        
        arrow.SetActive(true);
        arrow.transform.position = transform.position;

        ammount.Normalize();

        //ammount = (arrow.transform.position - ammount);

        //arrow.transform.Rotate(new Vector3(0, 0, 1), Vector3.Angle(new Vector3(1, 0, 0), ammount));
        //arrow.transform.rotation.SetEulerAngles(ammount);

        float angle = Vector3.Angle(Vector3.left, ammount);
        
        //arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, Quaternion.AngleAxis(angle>180? angle : -angle , new Vector3(0, 0, 1)), 1);

        arrow.transform.rotation = ammount.y < 0 ? Quaternion.AngleAxis(angle, -Vector3.forward) : Quaternion.AngleAxis(angle, Vector3.forward);

        //Debug.Log("A " + ammount + "   " + Vector3.Angle(new Vector3(1, 0, 0), ammount));

        throwDirection = arrow.transform.GetChild(0).position - arrow.transform.position;
    }

    public void ThrowObject(Vector3 v)
    {
        if (carringObject)
        {
            arrow.SetActive(false);
            preparingToAttack = false;
            Debug.Log("T");
            objectCarried.ThrowObject(v);
            objectCarried = null;
        }
    }

    public void Death()
    {
        gManager.PlayerDeath(IDPlayer);

    }

    private float _speed = 5f;
    public float speed {

        get { return _speed; }
        set
        {
            _speed = value;
            
        }
    
    
    }

    private bool _isJumping = false;
    public bool isJumping { 
        get { return _isJumping; }
        set { _isJumping = value; } 
    }

    public int jumpsMax = 3;
    public int jumpsCount = 0;


    public void Jump(Vector2 v)
    {
        if (jumpsCount >= jumpsMax)
        {
            return;
        }
        rigidbody2D.AddForce(v * 250);
        isJumping = true;
        StartCoroutine(jumpingTime());
        jumpsCount++;
    }

    IEnumerator jumpingTime()
    {
        yield return new WaitForSeconds(0.5f);
        isJumping = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.y > transform.position.y && (other.gameObject.layer == 9 || other.gameObject.layer == 14))
        {
            StartCoroutine(ignoreCollisionCountDown(other.collider, rigidbody2D.velocity));
        }
        else if(other.transform.position.y <= transform.position.y)
        {

            isJumping = false;
            jumpsCount = 0;
        }



        
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.collider2D.tag == "Throw")
        {
            PickUpObject(other.gameObject.GetComponent<Throwable>());
        }  
    }


    IEnumerator ignoreCollisionCountDown(Collider2D other, Vector2 velocity)
    {
        Debug.Log("Por debajo");
        rigidbody2D.velocity = velocity;
        Physics2D.IgnoreCollision(collider2D, other, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(collider2D, other, false);
    }

    public bool preparingToAttack = false;


    public void Update()
    {
        if (preparingToAttack)
        {
            //Moving = true;
            DrawArrow();
        }
        else
        {
            arrow.SetActive(false);
        }
    }
}
