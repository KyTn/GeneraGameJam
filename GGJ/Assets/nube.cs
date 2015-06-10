using UnityEngine;
using System.Collections;
using DG.Tweening;

public class nube : MonoBehaviour {
    public int y;
	// Use this for initialization
	void Start () {
        //this.gameObject.rigidbody2D.velocity = new Vector2(Random.RandomRange(x1,x2), 0);
        //Vector3[] aux = new Vector3 [4];

        //aux[3] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);
        //aux[0] = (transform.position + aux[3]) / 4;
        //aux[0].y += y;
            
        //    //new Vector3 (((transform.position.x+transform.position.x+25)/4),transform.position.y-y, transform.position.z);
        //aux[1] = ((transform.position + aux[3]) / 2);
        //aux[1].y -= y;

        ////new Vector3 (((transform.position.x+transform.position.x+25)/4)*2,transform.position.y+y, transform.position.z);
        //aux[2] = ((transform.position + aux[3]) / 4);
        //aux[2].y += y;
        //    //new Vector3 (((transform.position.x+transform.position.x+25)/4)*3,transform.position.y-y, transform.position.z);
        
        //transform.DOPath(aux, 10f,PathType.CatmullRom,PathMode.Full3D,5);

        transform.DOMove(new Vector3(transform.position.x + 25, transform.position.y, transform.position.z),10);
        Destroy(this.gameObject, 15f);
	}
	
	// Update is called once per frame
	
}
