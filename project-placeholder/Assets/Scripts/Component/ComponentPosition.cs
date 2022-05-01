using UnityEngine;

public class ComponentPosition : MonoBehaviour {
    public HexCoordinates hexPos;

    void Update() {
        Vector3 pos = transform.position;
        hexPos = HexCoordinates.FromPosition(pos);
        transform.position = hexPos.WorldPositionFromHexCoordinates(hexPos);
    }
}
