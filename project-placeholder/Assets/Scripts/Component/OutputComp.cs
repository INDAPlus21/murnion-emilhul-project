using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputComp : MonoBehaviour {
    public Element.ElementType element; 

    HexComponents grid;

    void Awake() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
    }
    
    public void Activate(int x, int y) {

    }

    public bool CheckOutput(int x, int y) {
        Element e = grid.CheckElement(x, y);
        return(e != null && e.type == element);
    }
}
