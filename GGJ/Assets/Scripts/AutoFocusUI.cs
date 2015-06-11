using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class AutoFocusUI : MonoBehaviour {

    public Button b;

	// Use this for initialization
	void Start () {



        EventSystem.current.SetSelectedGameObject(b.gameObject, null);
        //b.OnPointerClick(new PointerEventData(EventSystem.current));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
