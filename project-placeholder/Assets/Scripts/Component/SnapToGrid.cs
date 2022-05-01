using UnityEngine;

public class SnapToGrid : MonoBehaviour {
    public HexCoordinates hexPos;

    void Update() {
        Vector3 pos = transform.position;
        hexPos = HexCoordinates.FromPosition(pos);
        transform.position = hexPos.WorldPositionFromHexCoordinates(hexPos);
    }
}
