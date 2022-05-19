using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HexComponents : MonoBehaviour
{
    public HexComponent componentPrefab;
    HexComponent[,] components;
    public int height;
    public int width;

    void Awake() {
        HexGrid grid = (HexGrid)transform.parent.GetComponent("HexGrid");
        width = grid.width;
        height = grid.height;
        components = new HexComponent[width, height];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateComponent(HexCoordinates coordinates) {
        (int, int) arrayPos = GridPosToArrayPos((GridCoordinates)coordinates, height);
        if (components[arrayPos.Item1, arrayPos.Item2] == null) {
            Vector3 worldPos = coordinates.WorldPositionFromHexCoordinates(coordinates);

            HexComponent component = components[arrayPos.Item1, arrayPos.Item2] = Instantiate<HexComponent>(componentPrefab);
            component.Init(2, Direction.Northeast);
            component.transform.SetParent(transform, false);
            component.transform.localPosition = worldPos;
        } else {
            Dictionary<(int, int), (int, int)> moves = components[arrayPos.Item1, arrayPos.Item2].Activate(Function.Push);
        }
    }
    
    public GridCoordinates ArrayPosToGridPos(int x, int y, int maxHeight) {
        int gridX = x - (int)Math.Floor((double)y/2);
        int gridY = y - maxHeight/2;
        int gridZ = -x - y;

        GridCoordinates coords = new GridCoordinates(gridX, gridY, gridZ);
        return coords;
    }

    public (int, int) GridPosToArrayPos(GridCoordinates coords, int maxHeight) {
        int y = coords.y + maxHeight/2;
        int x = coords.x + (int)Math.Floor((double)y/2);

        (int, int) arrayPos = (x, y);
        return arrayPos;
    }
}

public struct GridCoordinates {
    public int x;
    public int y;
    public int z;

    public GridCoordinates(int _x, int _y, int _z) {
        x = _x;
        y = _y;
        z = _z;
    }

    public static explicit operator GridCoordinates(HexCoordinates coords) => new GridCoordinates(coords.X, coords.Y, -coords.X - coords.Y);
}
