using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour {
    public GameObject element; 

    HexComponents grid;

    void Awake() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
    }
    public void Activate(int x, int y) {
        if(grid.CheckElement(x, y)) {
            grid.RemoveElement(x, y);
        }
    }
}
