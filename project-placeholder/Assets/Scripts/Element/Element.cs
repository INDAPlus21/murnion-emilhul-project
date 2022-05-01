using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
    public HexCoordinates hexPos;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        hexPos = HexCoordinates.FromPosition(pos);
        transform.position = hexPos.WorldPositionFromHexCoordinates(hexPos);
    }
}
