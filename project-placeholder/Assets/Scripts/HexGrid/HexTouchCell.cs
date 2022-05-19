using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTouchCell : MonoBehaviour {

    public HexComponent componentPrefab;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
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
        HexComponents componentGrid = (HexComponents)(transform.GetComponentInChildren(typeof(HexComponents)));
        
        componentGrid.CreateComponent(coordinates, componentPrefab);
    }
}
