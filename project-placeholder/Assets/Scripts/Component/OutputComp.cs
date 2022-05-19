using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputComp : MonoBehaviour {
    public Element.ElementType element; 
    Material mat;
    HexComponents grid;

    void Start() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
        mat = transform.GetComponent<Renderer>().material;
        UpdateColor();
    }
    
    public void Activate(int x, int y) {

    }

    public bool CheckOutput(int x, int y) {
        Element e = grid.CheckElement(x, y);
        return(e != null && e.type == element);
    }

    public void UpdateColor() {
        mat.color = Element.GetElementColor(element);
    }
}
