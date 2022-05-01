using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {
    public float distance = 3f;
    // Update is called once per frame
    void Update() {
        float hexDistance = (1 + 2*distance) * HexMetrics.innerRadius + distance*0.5f;
        Ray beam = new Ray(transform.position, transform.right);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.right * hexDistance, Color.red);
        if(Physics.Raycast(beam, out hit, hexDistance)) {
            Push(hit.transform);
        }
    }

    void Push(Transform hit) {
        Vector3 pos =  hit.position;
        HexCoordinates hexPos = HexCoordinates.FromPosition(pos);
        hit.position = hexPos.WorldPositionFromHexCoordinates(hexPos);
    }
}
