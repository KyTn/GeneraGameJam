using UnityEngine;
using System.Collections;

public class LoaderScenes : MonoBehaviour {

    public int p1 = 0;
    public int p2 = 0;

    public void load1P()
    {
        Application.LoadLevel(p1);

    }

    public void load2P()
    {
        Application.LoadLevel(p2);

    }
}
