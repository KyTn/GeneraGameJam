using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerObjects : MonoBehaviour {

    public bool mocosoft, poogle, presente, futuro;

    public GameManager gManager;
    float seconds = 8;
    float secondsUmbral = 2;
    public void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            List<GameObject> l = new List<GameObject>();
            if (mocosoft && presente) { l = gManager.ThrowablesMocoSoftPresente; }
            else if (mocosoft && futuro) { l = gManager.ThrowablesMocoSoftFuturo; }
            else if (poogle && presente) { l = gManager.ThrowablesPooglePresente; }
            else if (poogle && futuro) { l = gManager.ThrowablesPoogleFuturo; }

            GameObject g = Instantiate(l[Random.Range(0, l.Count)]) as GameObject;
            g.transform.parent = transform;
            g.transform.localPosition = Vector3.zero;




            yield return new WaitForSeconds(seconds + Random.Range(-secondsUmbral, secondsUmbral));
        }
    }
}
