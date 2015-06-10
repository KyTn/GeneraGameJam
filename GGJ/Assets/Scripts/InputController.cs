using UnityEngine;
using UnityEngine.UI;
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
    Vector3 lastDownTouchPJ1;
    int IDtouchPJ1;

    Vector3 lastTouchPJ2;
    Vector3 lastDownTouchPJ2;
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
                lastTouch = camera.ScreenToWorldPoint(Input.GetTouch(i).position);
                
                if (lastTouch.x < 0)
                {
                    // Ha pulsado el jugador 1

                    lastDownTouchPJ1 = lastTouch;
                    // Acaba de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        lastTouchPJ1 = lastTouch;

                    }

                    // Esta moviendo el dedo por la pantalla
                    if (Input.GetTouch(i).phase == TouchPhase.Moved && (lastTouch.x != lastDownTouchPJ1.x || lastTouch.y != lastDownTouchPJ1.y))
                    {
                        PJ1Dragging = true;

                        if (PJ1Dragging)
                        {
                            // Ha arrastrado ... lanza !!
                            gManager.PJ1.ThrowObject(lastDownTouchPJ1 - lastTouchPJ1);

                        }
                        else
                        {
                            // Solo intenta moverse

                            from = lastDownTouchPJ1;
                            to = from;
                            from.z = 10;
                            to.z = -20;

                            Ray r = new Ray(from, to);
                            RaycastHit2D ray = Physics2D.GetRayIntersection(r);

                            Debug.Log("checked!: pj1");

                            if (ray.collider != null && ray.collider.tag == "BuildingHigh")
                            {
                                gManager.PJ1.MoveTo(ray.collider.transform.position);

                            }
                        }
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
                    lastDownTouchPJ2 = lastTouch;
                    // Acaba de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        lastTouchPJ2 = lastTouch;

                    }

                    // Esta moviendo el dedo por la pantalla
                    if (Input.GetTouch(i).phase == TouchPhase.Moved && (lastTouch.x != lastDownTouchPJ2.x || lastTouch.y != lastDownTouchPJ2.y))
                    {
                        PJ2Dragging = true;

                    }

                    // Ha dejado de pulsar
                    if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        if (PJ2Dragging)
                        {
                            // Ha arrastrado ... lanza !!
                            gManager.PJ2.ThrowObject(lastDownTouchPJ2 - lastTouchPJ2);
                        }
                        else
                        {
                            // Solo intenta moverse

                            from = lastDownTouchPJ2;
                            to = from;
                            from.z = 10;
                            to.z = -20;

                            Ray r = new Ray(from, to);
                            RaycastHit2D ray = Physics2D.GetRayIntersection(r);

                            Debug.Log("checked!: pj1");

                            if (ray.collider != null && ray.collider.tag == "BuildingHigh")
                            {
                                gManager.PJ2.MoveTo(ray.collider.transform.position);

                            }
                        }

                        PJ2Dragging = false;

                    }
                    
                }
            }



        }

        #endregion


    }
}
