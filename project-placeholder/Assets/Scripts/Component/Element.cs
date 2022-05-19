using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
    Material mat;
    public ElementType type;

    public enum ElementType {
        Debug,
        Salt,
    }

    void Awake() {
        mat = transform.GetComponent<Renderer>().material;
        UpdateColor();
    }
    public void UpdateColor() {
        mat.color = GetElementColor(type);
    }

    public static Color GetElementColor(ElementType type) {
        switch(type) {
            case ElementType.Debug:
                return Color.black;
            case ElementType.Salt:
                return Color.white;
        }
        return Color.black;
    }
}
