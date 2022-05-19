using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComp : HexComponent
{
    // Start is called before the first frame update
    public Element.ElementType element; 

    int x;
    int y;

    HexComponents grid;

    void Start() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
        HexCoordinates hexPos = HexCoordinates.FromPosition(transform.position);
        (int, int) arrayPos = HexComponents.HexPosToArrayPos(hexPos);
        x = arrayPos.Item1;
        y = arrayPos.Item2;
    }
     
    public override Dictionary<(int, int), (int, int)> Activate(Function c) {
        if(!grid.CheckElement(x, y)) {
            grid.CreateElement(x, y, element);
        }
        return new Dictionary<(int, int), (int, int)>();
    }

    public override void Init(int _length, Direction _dir) {
        return;
    }

    public override void Debug() {
        return;
    }
}
