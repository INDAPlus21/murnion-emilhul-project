using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {
    public int width = 20;
    public int height = 20;
    public HexCell cellPrefab;
    public Text cellLabelPrefab;
    Canvas gridCanvas;

    HexCell[] cells; 
    HexMesh hexMesh;

    void Awake () {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[height * width];

        for (int x = -width/2, i = 0; x < width/2; x++) {
            for (int y = -height/2; y < height/2; y++) {
                CreateCell(x, y, i++);
            }
        }
    }

    void Start () {
        hexMesh.Triangulate(cells);
    }

    void CreateCell (int x, int y, int i) {
        Vector3 position;
        position.x = (x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f + 0.5f);
        position.y = y * (HexMetrics.outerRadius * 1.5f + 0.5f);
        position.z = 100f;

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.y);
        label.text = cell.coordinates.ToStringOnSeperateLines();
    }
}
