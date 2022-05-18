using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HexComponents : MonoBehaviour
{
    public GameObject componentPrefab;
    public GameObject elementPrefab;
    GameObject[,] components;
    GameObject[,] elements;
    public static int height;
    public static int width;

    void Awake() {
        HexGrid grid = (HexGrid)transform.parent.GetComponent("HexGrid");
        width = grid.width;
        height = grid.height;
        components = new GameObject[width, height];
        elements = new GameObject[width, height];
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
        (int, int) arrayPos = HexPosToArrayPos(coordinates);
        Vector3 worldPos = coordinates.WorldPositionFromHexCoordinates(coordinates);

        GameObject component = components[arrayPos.Item1, arrayPos.Item2] = Instantiate<GameObject>(componentPrefab, transform, false);
        component.transform.localPosition = worldPos;
    }

    public void CreateElement(int x, int y, Element.ElementType transType) {
        HexCoordinates coords = ArrayPosToHexPos(x, y);
        Vector3 worldPos = coords.WorldPositionFromHexCoordinates(coords);

        worldPos.z = 10;

        GameObject element = elements[x, y] = Instantiate<GameObject>(elementPrefab, transform);
        TransformElement(x, y, transType);
        element.transform.localPosition = worldPos;
    }

    public void RemoveElement(int x, int y) {
        GameObject element = elements[x, y];
        Destroy(element);
    }

    public Element CheckElement(int x, int y) {
        Element e = null;
        if (elements[x, y]) {
            e = elements[x, y].GetComponent<Element>();
        }
        return (e);
    }

    public void TransformElement(int x, int y, Element.ElementType transType) {
        Element element = elements[x, y].GetComponent<Element>();
        element.type = transType;
        element.UpdateColor();
    }

    public static (int, int) HexPosToArrayPos(HexCoordinates coords) {
        int y = coords.Y + height/2;
        int x = coords.X + (int)Math.Floor((double)y/2);

        (int, int) arrayPos = (x, y);
        return arrayPos;
    }

    public HexCoordinates ArrayPosToHexPos(int x, int y) {
        int hexX = x - (int)Math.Floor((double)y/2);
        int hexY = y - height/2;

        HexCoordinates coords = new HexCoordinates(hexX, hexY);
        return coords;
    }

}
