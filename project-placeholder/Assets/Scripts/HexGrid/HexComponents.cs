using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HexComponents : MonoBehaviour {

    public static bool playingTrack = false;

    public int instructionsPerSecond = 10;
    private int framesSinceLastInstruction = 0;
    private int framesPerInstruction;

    private const int FramesPerSecond = 50;

    public GameObject elementPrefab;
    HexComponent[,] components;
    GameObject[,] elements;
    public static int height;
    public static int width;

    void Awake() {
        HexGrid grid = (HexGrid)transform.parent.GetComponent("HexGrid");
        width = grid.width;
        height = grid.height;
        components = new HexComponent[width, height];
        elements = new GameObject[width, height];
    }

    // Start is called before the first frame update
    void Start() {
        framesPerInstruction = FramesPerSecond / instructionsPerSecond;
    }

    // 50 calls per second
    // 50 / instruction per second = timeBetween instrcutions.
    void FixedUpdate() {
        if(playingTrack) {
            framesSinceLastInstruction++;
            if(framesSinceLastInstruction % framesPerInstruction == 0) {
                foreach(HexComponent comp in components) {
                    if(comp) comp.Activate(Function.Push);
                }
                framesSinceLastInstruction = 0;
            }
        } else {
            framesSinceLastInstruction = 0;
        }
    }

    public void CreateComponent(HexCoordinates coordinates, HexComponent componentPrefab) {
        (int, int) arrayPos = HexPosToArrayPos(coordinates);
        if (components[arrayPos.Item1, arrayPos.Item2] == null) {
            Vector3 worldPos = coordinates.WorldPositionFromHexCoordinates(coordinates);

            HexComponent component = components[arrayPos.Item1, arrayPos.Item2] = Instantiate<HexComponent>(componentPrefab, transform, false);
            component.Init(2, Direction.Northeast);
            component.transform.localPosition = worldPos;
        } else {
            Dictionary<(int, int), (int, int)> moves = components[arrayPos.Item1, arrayPos.Item2].Activate(Function.Push);
        }
    }

    public HexComponent CompFromGrid(int x, int y) {
        return components[x, y];
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
