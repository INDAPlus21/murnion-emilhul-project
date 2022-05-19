using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour  { 
    public virtual Dictionary<(int, int), (int, int)> Activate(Function c) { 
        return new Dictionary<(int, int), (int, int)>();
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