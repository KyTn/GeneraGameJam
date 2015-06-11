using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Buildings : MonoBehaviour {

    public float _life=1f;
    public float duracion=10f;

    public float life


    
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;

            if (_life <= 0f)
            {
                destruyeEdificio();
            }
            Debug.Log("vida: " + _life);
        }
    }
    public float damage=0.2f;
    public SkeletonAnimation skeletonAnimation;
	// Use this for initialization
	void Start () {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
	}

    
	
	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            life -= damage;
            skeletonAnimation.state.SetAnimation(0, "GOLPE", false);
        }
        
    }

    void destruyeEdificio()
    {
        Debug.Log("Muelte mujel!");
        skeletonAnimation.state.SetAnimation(0, "GOLPE", true);
        transform.parent.DOMove(new Vector3(transform.position.x,transform.position.y-100,transform.position.z),duracion);
        
        Destroy(this.gameObject, 10f);

    }
}
