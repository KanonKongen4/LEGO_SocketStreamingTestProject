using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//:) This script is responsible for:
public class ChangeColor : MonoBehaviour
{
    public Renderer objectRenderer;
    private Color matColor;
    async void Start()
    {
        objectRenderer = GetComponent<Renderer>();

    }
    void Update()
    {
        objectRenderer.material.color = matColor;
    }


    //Set color to the Material
    private void SetColors(string data)
    {
        string[] colors = data.Split(',');
        matColor = new Color()
        {
            r = float.Parse(colors[0]) / 255.0f,
            g = float.Parse(colors[1]) / 255.0f,
            b = float.Parse(colors[2]) / 255.0f,
            a = float.Parse(colors[3]) / 255.0f
        };

    }
}