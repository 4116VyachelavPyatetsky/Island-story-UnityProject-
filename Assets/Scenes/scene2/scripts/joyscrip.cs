using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joyscrip : MonoBehaviour
{
    private Vector3 MousePos;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            Touch touch = Input.GetTouch(0);
            gameObject.transform.position = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0.0f);
        }
    }
}
