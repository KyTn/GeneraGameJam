using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    bool touching = false;


	// Use this for initialization
	void Start () {
	
	}

    Vector2 firstTouchPosition;
    Vector2 lastTouchPosition;
	void Update () {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstTouchPosition = Input.touches[0].position;
                
                // Comprobar si hay algo en el mundo

            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Si no se estan moviendo, entonces es tiempo de disparar
                lastTouchPosition = Input.touches[0].position;
                DrawArrowIndicator(firstTouchPosition, lastTouchPosition);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // Si has levantado el dedo ... 
            }
        }
	}

    private void DrawArrowIndicator(Vector2 firstTouchPosition, Vector2 lastTouchPosition)
    {
       
    }
}
