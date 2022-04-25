using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTouchCell : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            HandleInput();
        }
    }

    void HandleInput() {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)) {
            TouchCell(hit.point);
        }
    }
    
    void TouchCell(Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);

        // Do what you want to do when a cell is clicked.

        Debug.Log("Touched at " + coordinates.ToString());
    }
}
