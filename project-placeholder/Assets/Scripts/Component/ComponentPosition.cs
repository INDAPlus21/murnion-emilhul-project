using UnityEngine;

public class ComponentPosition : MonoBehaviour {
    public HexCoordinates hexPos;

    void Update() {
        Vector3 pos = transform.position;
        hexPos = HexCoordinates.FromPosition(pos);
        transform.position = hexPos.WorldPositionFromHexCoordinates(hexPos);
    }
}

public enum Function {
    Push,
    Pull,
    RotateLeft,
    RotateRight,
}

public enum Direction {
    East,
    Northeast,
    Southeast,
    West,
    Northwest,
    Southwest,
}

