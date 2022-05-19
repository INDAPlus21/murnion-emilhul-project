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
            InputComp ic = hit.transform.GetComponent<InputComp>();
            OutputGroup og = hit.transform.GetComponent<OutputGroup>();
            TransformerComp tc = hit.transform.GetComponent<TransformerComp>();
            if(ic != null) {
                (int, int) arrayPos = HexComponents.HexPosToArrayPos(HexCoordinates.FromPosition(hit.point));
                ic.Activate(arrayPos.Item1, arrayPos.Item2);
            } else if(og != null) {
                (int, int) arrayPos = HexComponents.HexPosToArrayPos(HexCoordinates.FromPosition(hit.point));
                og.Activate(arrayPos.Item1, arrayPos.Item2);
            } else if(tc != null) {
                (int, int) arrayPos = HexComponents.HexPosToArrayPos(HexCoordinates.FromPosition(hit.point));
                tc.Activate(arrayPos.Item1, arrayPos.Item2);
            } else {
                TouchCell(hit.point);
            }
        }
    }
    
    void TouchCell(Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        HexComponents componentGrid = (HexComponents)(transform.GetComponentInChildren(typeof(HexComponents)));
        
        componentGrid.CreateComponent(coordinates, componentPrefab);
    }
}
