using UnityEngine;
using System.Collections;

public class Throwable : MonoBehaviour {

    public int carriedBy = 0; // 0 en el suelo (puede ser cogido), 1 lo tiene J1, 2 lo tiene J2

    public float speed;

    public void ThrowObject(Vector3 v)
    {
        rigidbody2D.isKinematic = false;
        transform.parent = null;
        rigidbody2D.AddForce(v * speed);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
