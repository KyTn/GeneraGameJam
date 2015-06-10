using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
    public Camera camera;
    public GameManager gManager;
    bool touching = false;


	// Use this for initialization
	void Start () {
	
	}

    Vector2 firstTouchPosition;
    Vector2 lastTouchPosition;
    Vector3 to, from;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            from = camera.ScreenToWorldPoint(Input.mousePosition);

            if (from.x < 0)
            {
                // Ha tocado el jugador 1
                from.z = 10;
                to.z = -20;

                Ray r = new Ray(from, to);
                RaycastHit2D ray = Physics2D.GetRayIntersection(r);

                Debug.Log("checked!: pj1");

                if (ray.collider != null && ray.collider.tag == "BuildingHigh")
                {
                    gManager.PJ1.MoveTo(ray.collider.transform.position);

                    Debug.Log("checked!: pos " + Input.mousePosition);
                }
            }
            else
            {

            }







            

        }
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
