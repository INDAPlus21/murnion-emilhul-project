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
        switch(type) {
            case ElementType.Debug:
                mat.color = Color.black;
                break;
            case ElementType.Salt:
                mat.color = Color.white;
                break;
        }
    }
}
