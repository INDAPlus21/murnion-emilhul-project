using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputComp : HexComponent {
    public Element.ElementType element; 
    Material mat;
    HexComponents grid;

    void Start() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
        mat = transform.GetComponent<Renderer>().material;
        UpdateColor();
    }
    
    public override Dictionary<(int, int), (int, int)> Activate(Function c) {
        return new Dictionary<(int, int), (int, int)>();
    }

    public override void Init(int _length, Direction _dir) {
        return;
    }

    public override void Debug() {
        return;
    }

    public void UpdateColor() {
        mat.color = Element.GetElementColor(element);
    }
}
