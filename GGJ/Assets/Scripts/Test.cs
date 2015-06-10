using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    Camera camera;
    public float width = 200;
    public float height = 200;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {

        Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y , 0));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}
