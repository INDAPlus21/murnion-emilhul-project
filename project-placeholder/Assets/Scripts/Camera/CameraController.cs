using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 dragOrigin;
    private Vector3 dragDiff;
    private bool drag;

    public float panSpeed = 45f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 7000f;
    public float minZoomSize, maxZoomSize;

    // Update is called once per frame
    void Update() {
        // Camera movement with drag
        if(Input.GetMouseButton(2)) {
            dragDiff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if(!drag) {
                drag = true;
                dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        } else {
            drag = false;
        }
        if(drag) {
            transform.position = dragOrigin - dragDiff;
        }

        Vector3 pos = transform.position;
        // Camera movement with WASD
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
                pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
                pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
                pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
                pos.y -= panSpeed * Time.deltaTime;
        }
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        transform.position = pos;
 
        // Camera scroll
        float fov = Camera.main.orthographicSize;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        fov -= scroll * scrollSpeed * Time.deltaTime;
        fov = Mathf.Clamp(fov, minZoomSize, maxZoomSize);
        Camera.main.orthographicSize = fov;
    }
}
