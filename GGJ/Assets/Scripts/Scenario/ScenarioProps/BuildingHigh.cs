using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingHigh : MonoBehaviour {

    /// <summary>
    /// 1 -> jugador 1, 2 -> jugador 2
    /// </summary>
    public int PlayerOwner = 0;

    public List<BuildingHigh> posiblePositions;

	void Start () {
        foreach (BuildingHigh b in posiblePositions)
        {
            if (!b.posiblePositions.Contains(this))
            {
                b.posiblePositions.Add(this);
            }
        }
	}

    void StartDestroyAnimation()
    {
        foreach (BuildingHigh b in posiblePositions)
        {
            if (!b.posiblePositions.Contains(this))
            {
                b.posiblePositions.Remove(this);
            }
        }


        Destroy(gameObject);
    }


}
