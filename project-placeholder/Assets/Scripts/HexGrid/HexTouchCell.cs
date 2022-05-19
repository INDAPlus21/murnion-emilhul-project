using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTouchCell : MonoBehaviour {

    public enum PrefabType {
        output,
        input,
        beam,
        transform,
    }

    public PrefabType type;

    public HexComponent outputGroupPrefab;
    public HexComponent inputPrefab;
    public HexComponent beamPrefab;
    public HexComponent transformPrefab;

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            PlaceComponent();
        }
        if(Input.GetKeyDown("o")) {
            type = PrefabType.output;
        }
        if(Input.GetKeyDown("i")) {
            type = PrefabType.input;
        }
        if(Input.GetKeyDown("b")) {
            type = PrefabType.beam;
        }
        if(Input.GetKeyDown("t")) {
            type = PrefabType.transform;
        }
        if(Input.GetKeyDown("p")) {
            if(HexComponents.playingTrack) {
                HexComponents.playingTrack = false;
            } else {
                HexComponents.playingTrack = true;
            }
        }
    }

    void PlaceComponent() {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit)) {
            TouchCell(hit.point);
        }
    }
    
    void TouchCell(Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        HexComponents componentGrid = (HexComponents)(transform.GetComponentInChildren(typeof(HexComponents)));

        switch(type) {
            case PrefabType.output:
                componentGrid.CreateComponent(coordinates, outputGroupPrefab);
                break;
            case PrefabType.input:
                componentGrid.CreateComponent(coordinates, inputPrefab);
                break;
            case PrefabType.beam:
                componentGrid.CreateComponent(coordinates, beamPrefab);
                break;
            case PrefabType.transform:
                componentGrid.CreateComponent(coordinates, transformPrefab);
                break;
        }

        
    }
}
