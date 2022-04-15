using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;
    public HexCell cellPrefab;

    HexCell[] cells;
    HexMesh hexMesh;

    void Awake () {
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[height * width];

        for (int x = 0, i = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                CreateCell(x, y, i++);
            }
        }
    }

    void Start () {
        hexMesh.Triangulate(cells);
    }

    void CreateCell (int x, int y, int i) {
        Vector3 position;
        position.x = (x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f);
        position.y = y * (HexMetrics.outerRadius * 1.5f);
        position.z = 100f;

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
}
