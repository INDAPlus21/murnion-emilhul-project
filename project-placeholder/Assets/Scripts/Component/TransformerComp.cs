using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerComp : HexComponent {
    public Element.ElementType type;

    int x;
    int y;

    HexComponents grid;

    void Awake() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
        HexCoordinates hexPos = HexCoordinates.FromPosition(transform.position);
        (int, int) arrayPos = HexComponents.HexPosToArrayPos(hexPos);
        x = arrayPos.Item1;
        y = arrayPos.Item2;
    }
    
    public override Dictionary<(int, int), (int, int)> Activate(Function c) {
        Dictionary<(int, int), (int, int)> moves = new Dictionary<(int, int), (int, int)>();
        if(grid.CheckElement(x, y)) {
            grid.TransformElement(x, y, type);
        }
        return moves;
    }

    public override void Init(int _length, Direction _dir) {
        return;
    }

    public override void Debug() {
        return;
    }
}
