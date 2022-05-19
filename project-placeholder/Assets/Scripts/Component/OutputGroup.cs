using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputGroup : MonoBehaviour {

    public GameObject outputPrefab;

    public int[] xs;
    public int[] ys;
    public Element.ElementType[] types;

    private (int, int, OutputComp)[] outputComps;

    HexComponents grid;

    void Start() {
        grid = (HexComponents)(transform.GetComponentInParent(typeof(HexComponents)));
        outputComps = new (int, int, OutputComp)[xs.Length];

        HexCoordinates hexPos = HexCoordinates.FromPosition(transform.position);

        for(int i = 0; i < xs.Length; i++) {
            HexCoordinates relativeHexPos = new HexCoordinates(hexPos.X + xs[i], hexPos.Y + ys[i]);
            grid.CreateComponent(relativeHexPos, outputPrefab);
            (int, int) relativeArrayPos = HexComponents.HexPosToArrayPos(relativeHexPos);
            OutputComp oc = grid.CompFromGrid(relativeArrayPos.Item1, relativeArrayPos.Item2).GetComponent<OutputComp>();
            oc.element = types[i];
            outputComps[i] = (relativeArrayPos.Item1, relativeArrayPos.Item2, oc);
        }
    }

    public void Activate(int x, int y) {
        foreach((int, int, OutputComp) pos in outputComps) {
            if(!pos.Item3.CheckOutput(pos.Item1, pos.Item2)) return;
        }
        foreach((int, int, OutputComp) pos in outputComps) {
            grid.RemoveElement(pos.Item1, pos.Item2);
        }
    }
}
