using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class maijs : MonoBehaviour
{
    public static float speed = 0.06f;
    GameObject jsb;
    GameObject js;
    public GameObject plane;
    public bool JoyStick = true;
    Vector3 MousePos;
    Vector3 spose;
    void Start()
    {
        Vector3 sz = gameObject.GetComponent<BoxCollider2D>().size;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector3(sz.x, sz.y*wavescript.screenSizePere, sz.z);
        jsb = GameObject.Find("jbase");
        js = GameObject.Find("jstick");
    }
    void FixedUpdate()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                jsb.transform.position = new Vector3(10000.0f, 10000.0f, 0.0f);
            }
            if (Input.GetMouseButton(0) && !JoyStick && !wavescript.gamestopped)
            {
                plane.transform.position = Vector2.MoveTowards(plane.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime * speed * 67f);
            }
        }
    }
    //plane.transform.position = Vector3.MoveTowards(plane.transform.position, spose, Time.deltaTime * speed);
    void OnMouseDown()
    {
        spose = Input.mousePosition;
        if (!wavescript.gamestopped && JoyStick)
        {
            jsb.transform.position = spose;
        }
    }
    void OnMouseDrag()
    {
        if (!wavescript.gamestopped && JoyStick)
        {
            Vector3 drag = Input.mousePosition;
            float A = Mathf.Sqrt(Mathf.Pow(drag.x - spose.x, 2) + Mathf.Pow(drag.y - spose.y, 2));
            if (A > 60)
            {
                float b = A / 60.0f;
                js.transform.position = new Vector3((drag.x - spose.x) / b + spose.x, (drag.y - spose.y) / b + spose.y, 0.0f);
            }
            else
            {
                js.transform.position = drag;
            }
            Vector3 boobs = js.transform.position - jsb.transform.position;
            float dopspeed = boobs.magnitude/60f;
            if (dopspeed < 0.5f)  dopspeed = 0.5f;
            if (A <= 60.0f)
            {
                plane.transform.Translate(boobs * Time.deltaTime * speed * dopspeed);
            }
            else
            {
                plane.transform.Translate(boobs * Time.deltaTime * speed * dopspeed);
            }
        }
    }
}
