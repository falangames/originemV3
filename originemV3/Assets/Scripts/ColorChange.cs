using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color color;
    public Renderer cubeRenderer;
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        cubeRenderer.material.color = color;
        cubeRenderer.material.SetColor("Color_59E17206", color);
    }
}
