using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodscoreY : MonoBehaviour
{
    public GameObject stonescore;
    public GameObject ram;
    float plus;
    // Start is called before the first frame update
    void Start()
    {
        SvoeMesto();
    }
    private void SvoeMesto()
    {
        float a = Screen.height;
        float b = Screen.width;
        float x = a / b;
        float y = 800.0f / 480.0f;
        plus = (x-y)/1.5f * transform.position.y;
        transform.position = new Vector3(transform.position.x, transform.position.y+plus,0);
        ram.transform.position = new Vector3(ram.transform.position.x, ram.transform.position.y + plus, 0);
    }
    public void Kamen()
    {
        stonescore.transform.position = new Vector3(stonescore.transform.position.x, stonescore.transform.position.y + plus, 0);
    }
}
