using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerComp : MonoBehaviour {
    public Element.ElementType type;

    HexComponents grid;

    void Awake() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
    }
    public void Activate(int x, int y) {
        if(grid.CheckElement(x, y)) {
            grid.TransformElement(x, y, type);
        }
    }
}
