using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTouchCell : MonoBehaviour
{
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
            InputComp ic = hit.transform.GetComponent<InputComp>();
            Output o = hit.transform.GetComponent<Output>();
            if(ic != null) {
                (int, int) arrayPos = HexComponents.HexPosToArrayPos(HexCoordinates.FromPosition(hit.point));
                ic.Activate(arrayPos.Item1, arrayPos.Item2);
            } else if(o != null) {
                (int, int) arrayPos = HexComponents.HexPosToArrayPos(HexCoordinates.FromPosition(hit.point));
                o.Activate(arrayPos.Item1, arrayPos.Item2);
            } else {
                TouchCell(hit.point);
            }
        }
    }
    
    void TouchCell(Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        HexComponents componentGrid = (HexComponents)(transform.GetComponentInChildren(typeof(HexComponents)));
        
        componentGrid.CreateComponent(coordinates);
    }
}
