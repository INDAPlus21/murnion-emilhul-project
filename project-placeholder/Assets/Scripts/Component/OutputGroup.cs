using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputGroup : HexComponent {

    public HexComponent outputPrefab;
    public Element.ElementType element; 
    Material mat;

    public int[] xs;
    public int[] ys;
    public Element.ElementType[] types;

    private (int, int, Element.ElementType)[] outputComps;

    HexComponents grid;

    void Start() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
        mat = transform.GetComponent<Renderer>().material;
        outputComps = new (int, int, Element.ElementType)[xs.Length];
        
        // First item is group leader
        HexCoordinates hexPos = HexCoordinates.FromPosition(transform.position);
        (int, int) arrayPos = HexComponents.HexPosToArrayPos(hexPos);
        element = types[0];
        outputComps[0] = (arrayPos.Item1, arrayPos.Item2, element);
        UpdateColor();

        for(int i = 1; i < xs.Length; i++) {
            HexCoordinates relativeHexPos = new HexCoordinates(hexPos.X + xs[i], hexPos.Y + ys[i]);
            UnityEngine.Debug.Log("Begin creating component...");
            grid.CreateComponent(relativeHexPos, outputPrefab);
            UnityEngine.Debug.Log("Finnish");
            (int, int) relativeArrayPos = HexComponents.HexPosToArrayPos(relativeHexPos);
            // Know bug. Will crash if other position would be on an already occupied spot.
            OutputComp oc = grid.CompFromGrid(relativeArrayPos.Item1, relativeArrayPos.Item2).GetComponent<OutputComp>();
            oc.element = types[i];
            outputComps[i] = (relativeArrayPos.Item1, relativeArrayPos.Item2, types[i]);
        }
    }

    public override Dictionary<(int, int), (int, int)> Activate(Function c) {
        Dictionary<(int, int), (int, int)> moves = new Dictionary<(int, int), (int, int)>();
        foreach((int, int, Element.ElementType) pos in outputComps) {
            if(!CheckOutput(pos.Item1, pos.Item2, pos.Item3)) return moves;
        }
        foreach((int, int, Element.ElementType) pos in outputComps) {
            grid.RemoveElement(pos.Item1, pos.Item2);
        }
        return moves;
    }

    public override void Init(int _length, Direction _dir) {
        return;
    }

    public override void Debug() {
        return;
    }

    private bool CheckOutput(int x, int y, Element.ElementType element) {
        Element e = grid.CheckElement(x, y);
        return(e != null && e.type == element);
    }

    public void UpdateColor() {
        mat.color = Element.GetElementColor(element);
    }
}
