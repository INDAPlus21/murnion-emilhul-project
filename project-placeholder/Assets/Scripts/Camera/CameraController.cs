using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float panSpeed = 45f;
    public Vector2 panLimit;
    public float scrollSpeed = 7000f;
    public float minZoomSize, maxZoomSize;
    
    // Update is called once per frame
    void Update() {
        // Camera movement with WASD
        Vector3 pos = transform.position;
        if (Input.GetKey("d")) {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a")) {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w")) {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s")) {
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
