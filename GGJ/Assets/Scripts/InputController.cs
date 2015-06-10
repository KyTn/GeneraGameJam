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

    public bool PJ1Dragging;
    public bool PJ2Dragging;

    Vector3 lastTouch;
    Vector3 lastTouchPJ1;
    int IDtouchPJ1;
    Vector3 lastTouchPJ2;
    int IDtouchPJ2;

    void Update()
    {

        if (PJ1Dragging)
        {
            lastTouch = camera.ScreenToWorldPoint(Input.mousePosition);
            if (lastTouch.x != lastTouchPJ1.x || lastTouch.y != lastTouchPJ1.y)
            {
                Debug.Log("Draggin PJ1");
            }
        }

        if (PJ2Dragging)
        {
            lastTouch = camera.ScreenToWorldPoint(Input.mousePosition);
            if (lastTouch.x != lastTouchPJ2.x || lastTouch.y != lastTouchPJ2.y)
            {
                Debug.Log("Draggin PJ2");
            }
        }

        #region USING MOUSE
        if (Input.GetMouseButtonUp(0))
        {
            lastTouch = camera.ScreenToWorldPoint(Input.mousePosition);

            if (lastTouch.x < 0)
            {
                // Levanta el dedo el jugador 1
                if (lastTouch.x != lastTouchPJ1.x || lastTouch.y != lastTouchPJ1.y)
                {
                    // PJ1 ha dejado de draggear
                    Debug.Log("PJ1 ha dejado de draggear");
                }
                else
                {
                    
                }
                PJ1Dragging = false;
            }
            else
            {
                // Levanta el dedo el jugador 2
                if (lastTouch.x != lastTouchPJ2.x || lastTouch.y != lastTouchPJ2.y)
                {
                    // PJ1 ha dejado de draggear
                    Debug.Log("PJ2 ha dejado de draggear");
                }
                else
                {

                }
                PJ2Dragging = false;
            }
        }



        if (Input.GetMouseButtonDown(0))
        {

            lastTouch = camera.ScreenToWorldPoint(Input.mousePosition);

            if (lastTouch.x < 0)
            {

                // Ha tocado el jugador 1

                lastTouchPJ1 = lastTouch;
                PJ1Dragging = true;



                //from.z = 10;
                //to.z = -20;

                //Ray r = new Ray(from, to);
                //RaycastHit2D ray = Physics2D.GetRayIntersection(r);

                //Debug.Log("checked!: pj1");

                //if (ray.collider != null && ray.collider.tag == "BuildingHigh")
                //{
                //    //gManager.PJ1.MoveTo(ray.collider.transform.position);

                //    Debug.Log("checked!: pos " + Input.mousePosition);
                //}

            }
            else
            {
                // Ha tocado el jugador 2
                
                lastTouchPJ2 = lastTouch;
                PJ2Dragging = true;

            }
        }

        #endregion 

        #region USING TOUCHES

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                lastTouch = Input.GetTouch(i).position;

                if (Input.GetTouch(i).position.x < 0)
                {
                    // Ha pulsado el jugador 1


                    // Acaba de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        lastTouchPJ1 = lastTouch;
                        
                    }

                    // Esta moviendo el dedo por la pantalla
                    if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        PJ1Dragging = true;
                    }

                    // Ha dejado de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        PJ1Dragging = false;
                    }
                    
                }
                else
                {
                    // Ha pulsado el jugador 2

                    // Acaba de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        lastTouchPJ2 = lastTouch;

                    }

                    // Esta moviendo el dedo por la pantalla
                    if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        PJ2Dragging = true;
                    }

                    // Ha dejado de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        PJ2Dragging = false;
                    }
                    
                }
            }



        }

        #endregion


    }

    private void DrawArrowIndicator(Vector2 firstTouchPosition, Vector2 lastTouchPosition)
    {
       
    }
}
