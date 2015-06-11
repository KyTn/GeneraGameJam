using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour {

    public int carriedBy = 0; // 0 en el suelo (puede ser cogido), 1 lo tiene J1, 2 lo tiene J2

    public float speed;

    public void ThrowObject(Vector3 v)
    {
        if (carriedBy == 1) gameObject.layer = 12;
        else gameObject.layer = 13;

        rigidbody2D.isKinematic = false;
        //collider2D.isTrigger = false;
        transform.parent = null;
        rigidbody2D.AddForce(v * speed);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.tag == "Building" && ( gameObject.layer == 12 || gameObject.layer == 13 ))
        {
            Buildings b = other.gameObject.GetComponent<Buildings>();
            b.life -= b.damage;

            GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (carriedBy == 1)
            {
                g.PJ1.money += g.premioGolpe;
            }
            else
            {
                g.PJ2.money += g.premioGolpe;
            }
            b.skeletonAnimation.state.SetAnimation(0, "GOLPE", false);
            Destroy(gameObject);
        }


    }

}
