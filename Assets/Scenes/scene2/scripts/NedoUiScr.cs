using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NedoUiScr : MonoBehaviour
{
    float x;
    void Start()
    {
        float a = Screen.height;
        float b = Screen.width;
        x = (a / b) / (800f / 480f);
        transform.position = new Vector3(transform.position.x, transform.position.y * x, 0);
    }

}
