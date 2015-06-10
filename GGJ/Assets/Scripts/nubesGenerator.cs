using UnityEngine;
using System.Collections;

public class nubesGenerator : MonoBehaviour {
    public GameObject nube;
	// Use this for initialization
	void Start () {
        StartCoroutine(generaNubes());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     IEnumerator generaNubes()
    {
        while (true)
        {
            GameObject nub= (Instantiate(nube, new Vector3(this.transform.position.x, this.transform.position.y + Random.RandomRange(-1f, 1f), this.transform.position.z), Quaternion.identity)) as GameObject;
            nub.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(-2, 2);
            yield return new WaitForSeconds(Random.RandomRange(2f, 5f));
        }
    }
}
